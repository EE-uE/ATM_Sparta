using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{
    public InputField UserID;
    public InputField Password;

    public GameObject LoginObj;         // �α���
    public GameObject SignUpObj;        // ȸ������
    public GameObject LoginErrorObj;    // �α��ο���â

    public void Login()
    {
        string id = UserID.text;
        PlayerPrefs.SetString("userid", id);
        string password = Password.text;

        if (GameManager.Instance.users.Count == 0)
        {
            GameManager.Instance.LoadUsers();
        }

        string path = Path.Combine(Application.dataPath, "SaveData", "userData.json");

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(password))
        {
            return;
        }

        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            UserDataList userDataList = JsonUtility.FromJson<UserDataList>(jsonData);

            UserData userData = userDataList.userDatas.Find(userData => userData.UserID == id && userData.Password == password);

            if (userData != null)
            {
                //GameManager.Instance.LoadUserData(id);
                OnLoginSuccess();  // �α��� ���� ó��
            }
            else
            {
                OnLoginErrorObjBtn();  // �α��� ���� ó��
            }
        }
    }

    public void OnLoginSuccess()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnSignUpObjBtn()
    {
        SignUpObj.SetActive(true);
    }

    public void OnLoginErrorObjBtn()
    {
        LoginErrorObj.SetActive(true);
    }
}
