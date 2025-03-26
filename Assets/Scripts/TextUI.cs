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

    // UI 업데이트
    public void Refresh()
    {
        if (GameManager.Instance.userData != null)
        {
            // userData가 null이 아닌 경우에만 텍스트 업데이트
            UserNameText.text = string.Format("{0:N0}", GameManager.Instance.userData.UserName);
            curBalance.text = string.Format("{0:N0}", GameManager.Instance.userData.Balance);
            curCash.text = string.Format("{0:N0}", GameManager.Instance.userData.Cash);
        }
    }
}
