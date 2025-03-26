using TMPro;
using UnityEngine;

public class TextUI : MonoBehaviour
{
    UserData userData;

    public TextMeshProUGUI UserNameText;
    public TextMeshProUGUI curBalance;
    public TextMeshProUGUI curCash;

    public void Start()
    {
        Refresh();
    }

    // UI ������Ʈ
    public void Refresh()
    {
        if (GameManager.Instance.userData != null)
        {
            // userData�� null�� �ƴ� ��쿡�� �ؽ�Ʈ ������Ʈ
            UserNameText.text = string.Format("{0:N0}", GameManager.Instance.userData.UserName);
            curBalance.text = string.Format("{0:N0}", GameManager.Instance.userData.Balance);
            curCash.text = string.Format("{0:N0}", GameManager.Instance.userData.Cash);
        }
    }
}
