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

    public GameObject BankMenu;     // 입출금
    public GameObject Deposit;      // 입금
    public GameObject Withdraw;     // 출금
    public GameObject Remittance;   // 송금
    public GameObject PopupError;   // 잔액부족창

    UserData userData;
    // GameManager.Instance.SaveUserData();
    // 매 기능에 넣지않고 Awake에 한번만 호출해줘도 됨, 아니면 저장할때만 사용하게 해주기

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
        // 입금금액이 0보다 커야함, 현금(Cash)이 입금금액보다 많거나 같은지
        if (amount > 0 && GameManager.Instance.userData.Cash >= amount)
        {
            GameManager.Instance.userData.Cash -= amount;
            GameManager.Instance.userData.Balance += amount;
        }
        else 
        {
            ErrorMessage.text = "현금이 부족합니다.";
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
            ErrorMessage.text = "잔액이 부족합니다.";
            PopupError.SetActive(true);
        }
        SaveManager.SaveUserData(GameManager.Instance.userData);
        textUI.Refresh();
    }

    public void RemInputMoney()
    {
        string inputName = inputRemname.text.Trim(); // 송금대상
        string inputMoney = inputRemdraw.text.Trim(); // 송금금액

        // 빈칸 확인
        if (string.IsNullOrEmpty(inputName) || string.IsNullOrEmpty(inputMoney))
        {
            ErrorMessage.text = "빈칸을 입력해주세요.";
            PopupError.SetActive(true);
            return;
        }

        // 금액 확인, 숫자로 변환 및 0이하의 값인지 확인
        if (!int.TryParse(inputMoney, out int amount) || amount <= 0)
        {
            ErrorMessage.text = "금액을 입력해주세요.";
            PopupError.SetActive(true);
            return;
        }

        // 받는 사람 찾기
        string userPath = Path.Combine(Application.dataPath, "SaveData", "userData.json");
        UserDataList userDataList = JsonUtilityManager.LoadUserDataList(userPath);
        UserData receiver = userDataList.userDatas.Find(user => user.UserName == inputName);
        if (receiver == null)
        {
            ErrorMessage.text = "송금대상을 확인해주세요.";
            PopupError.SetActive(true);
            return;
        }

        // 현재 사용자 확인 및 잔액확인, 잔액 부족시 실패 (게임매니저는 현 유저데이터)
        UserData sender = GameManager.Instance.userData;
        if (sender.Balance < amount)
        {
            ErrorMessage.text = "잔액이 부족합니다.";
            PopupError.SetActive(true);
            return;
        }

        // 송금 처리
        sender.Balance -= amount;
        receiver.Balance += amount;

        ErrorMessage.text = $"{sender.UserName} 님이 {receiver.UserName} 님에게\n{amount}원을 송금했습니다.";
        PopupError.SetActive(true);

        SaveUserDataList(userDataList, userPath);

        // 현재 로그인한 유저 정보도 업데이트, UI때문에 필요
        GameManager.Instance.userData = sender;
        textUI.Refresh();
    }

    private void SaveUserDataList(UserDataList userDataList, string filePath)
    {
        string json = JsonUtility.ToJson(userDataList, true);
        File.WriteAllText(filePath, json);
    }
}
