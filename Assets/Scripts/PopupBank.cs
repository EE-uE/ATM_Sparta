using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PopupBank : MonoBehaviour
{
    public TextUI textUI;
    public Text ErrorMessage;
    public InputField inputDeposit;
    public InputField inputWithdraw;
    public InputField inputRemname;
    public InputField inputRemdraw;

    public GameObject BankMenu;     // �����
    public GameObject Deposit;      // �Ա�
    public GameObject Withdraw;     // ���
    public GameObject Remittance;   // �۱�
    public GameObject PopupError;   // �ܾ׺���â

    UserData userData;
    // GameManager.Instance.SaveUserData();
    // �� ��ɿ� �����ʰ� Awake�� �ѹ��� ȣ�����൵ ��, �ƴϸ� �����Ҷ��� ����ϰ� ���ֱ�

    public void OnDepositBtn()
    {
        Deposit.SetActive(true);
        BankMenu.SetActive(false);
    }

    public void OnWithdrawtBtn()
    {
        Withdraw.SetActive(true);
        BankMenu.SetActive(false);
    }

    public void OnRemittanceBtn()
    {
        Remittance.SetActive(true);
        BankMenu.SetActive(false);
    }

    public void OnBankMenuBtn()
    {
        BankMenu.SetActive(true);
        Withdraw.SetActive(false);
        Deposit.SetActive(false);
        Remittance.SetActive(false);
    }

    public void DepositMoney(int amount)
    {
        if (amount == 0)
        {
            string inputText = inputDeposit.text.Trim();
            if (int.TryParse(inputText, out int parsedAmount))
            {
                amount = parsedAmount;
            }
        }
        // �Աݱݾ��� 0���� Ŀ����, ����(Cash)�� �Աݱݾ׺��� ���ų� ������
        if (amount > 0 && GameManager.Instance.userData.Cash >= amount)
        {
            GameManager.Instance.userData.Cash -= amount;
            GameManager.Instance.userData.Balance += amount;
        }
        else 
        {
            ErrorMessage.text = "������ �����մϴ�.";
            PopupError.SetActive(true);
        }
        SaveManager.SaveUserData(GameManager.Instance.userData);
        textUI.Refresh();
    }

    public void WithdrawMoney(int amount)
    {
        if (amount == 0)
        {
            string inputText = inputWithdraw.text.Trim();
            if (int.TryParse(inputText, out int parsedAmount))
            {
                amount = parsedAmount;
            }
        }
        if (amount > 0 && GameManager.Instance.userData.Balance >= amount)
        {
            GameManager.Instance.userData.Balance -= amount;
            GameManager.Instance.userData.Cash += amount;
        }
        else
        {
            ErrorMessage.text = "�ܾ��� �����մϴ�.";
            PopupError.SetActive(true);
        }
        SaveManager.SaveUserData(GameManager.Instance.userData);
        textUI.Refresh();
    }

    public void RemInputMoney()
    {
        string inputName = inputRemname.text.Trim(); // �۱ݴ��
        string inputMoney = inputRemdraw.text.Trim(); // �۱ݱݾ�

        // ��ĭ Ȯ��
        if (string.IsNullOrEmpty(inputName) || string.IsNullOrEmpty(inputMoney))
        {
            ErrorMessage.text = "��ĭ�� �Է����ּ���.";
            PopupError.SetActive(true);
            return;
        }

        // �ݾ� Ȯ��, ���ڷ� ��ȯ �� 0������ ������ Ȯ��
        if (!int.TryParse(inputMoney, out int amount) || amount <= 0)
        {
            ErrorMessage.text = "�ݾ��� �Է����ּ���.";
            PopupError.SetActive(true);
            return;
        }

        // �޴� ��� ã��
        string userPath = Path.Combine(Application.dataPath, "SaveData", "userData.json");
        UserDataList userDataList = JsonUtilityManager.LoadUserDataList(userPath);
        UserData receiver = userDataList.userDatas.Find(user => user.UserName == inputName);
        if (receiver == null)
        {
            ErrorMessage.text = "�۱ݴ���� Ȯ�����ּ���.";
            PopupError.SetActive(true);
            return;
        }

        // ���� ����� Ȯ�� �� �ܾ�Ȯ��, �ܾ� ������ ���� (���ӸŴ����� �� ����������)
        UserData sender = GameManager.Instance.userData;
        if (sender.Balance < amount)
        {
            ErrorMessage.text = "�ܾ��� �����մϴ�.";
            PopupError.SetActive(true);
            return;
        }

        // �۱� ó��
        sender.Balance -= amount;
        receiver.Balance += amount;

        ErrorMessage.text = $"{sender.UserName} ���� {receiver.UserName} �Կ���\n{amount}���� �۱��߽��ϴ�.";
        PopupError.SetActive(true);

        SaveUserDataList(userDataList, userPath);

        // ���� �α����� ���� ������ ������Ʈ, UI������ �ʿ�
        GameManager.Instance.userData = sender;
        textUI.Refresh();
    }

    private void SaveUserDataList(UserDataList userDataList, string filePath)
    {
        string json = JsonUtility.ToJson(userDataList, true);
        File.WriteAllText(filePath, json);
    }
}
