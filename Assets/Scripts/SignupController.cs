using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SignupController : MonoBehaviour
{
    public InputField UserID;
    public InputField UserName;
    public InputField Password;
    public InputField PasswordCheck;

    public Button SuBtn;

    public Text SignMessage;

    public void SignUp()
    {
        // 아이디생성
        string id = UserID.text;
        string path = Path.Combine(Application.dataPath, "SaveData", "userData.json");
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            UserDataList userDataList = JsonUtility.FromJson<UserDataList>(jsonData);
            foreach (UserData userData in userDataList.userDatas)
            {
                if (userData.UserID == id)
                {
                    SignMessage.text = "중복되는 ID가 있습니다.";
                    return;
                }
            }
        }

        // 비밀번호확인
        string pw = Password.text;
        string check = PasswordCheck.text;
        if (pw != check)
        {
            SignMessage.text = "비밀번호가 일치하지 않습니다.";
            return;
        }

        SignUpSuccess();
        SignMessage.text = "회원가입이 완료되었습니다.";
    }

    public void SignUpSuccess()
    {
        UserData userData = new UserData(UserID.text, Password.text, UserName.text, 0, 0);

        string path = Path.Combine(Application.dataPath, "SaveData", $"{userData.UserID}.json");

        UserDataList userDataList = new UserDataList();

        if (File.Exists(path))
        {
            string existingData = File.ReadAllText(path);
            userDataList = JsonUtility.FromJson<UserDataList>(existingData);
        }

        userDataList.userDatas.Add(userData);

        string newData = JsonUtility.ToJson(userDataList, true);
        File.WriteAllText(path, newData);

        AddToUserDataList(userData);
    }

    public void AddToUserDataList(UserData userData)
    {
        string path = Path.Combine(Application.dataPath, "SaveData", "userData.json");
        UserDataList userDataList = new UserDataList();

        if (File.Exists(path))
        {
            string existingData = File.ReadAllText(path);
            userDataList = JsonUtility.FromJson<UserDataList>(existingData);
        }

        userDataList.userDatas.Add(userData);

        string newData = JsonUtility.ToJson(userDataList, true);
        File.WriteAllText(path, newData);
    }
}
