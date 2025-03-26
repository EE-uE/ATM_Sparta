using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{
    public InputField UserID;
    public InputField Password;

    public GameObject LoginObj;         // 로그인
    public GameObject SignUpObj;        // 회원가입
    public GameObject LoginErrorObj;    // 로그인에러창

    public void Login()
    {
        // 로그인한 유저 정보를 PlayerPrefs에 저장
        string id = UserID.text;
        PlayerPrefs.SetString("userid", id);
        string password = Password.text;

        // 유저 데이터가 없으면 정보를 불러옴
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

            // 입력한 정보와 일치하는 유저 찾기
            UserData userData = userDataList.userDatas.Find(userData => userData.UserID == id && userData.Password == password);

            if (userData != null)
            {
                OnLoginSuccess();  // 로그인 성공 처리
            }
            else
            {
                OnLoginErrorObjBtn();  // 로그인 실패 처리
            }
        }
    }

    public void OnLoginSuccess()
    {
        SceneManager.LoadScene("MainScene");
    }

    // 회원가입 
    public void OnSignUpObjBtn()
    {
        SignUpObj.SetActive(true);
    }

    public void OnLoginErrorObjBtn()
    {
        LoginErrorObj.SetActive(true);
    }
}
