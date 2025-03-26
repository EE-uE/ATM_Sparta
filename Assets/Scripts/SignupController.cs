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
        // ���̵����
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
                    SignMessage.text = "�ߺ��Ǵ� ID�� �ֽ��ϴ�.";
                    return;
                }
            }
        }

        // ��й�ȣȮ��
        string pw = Password.text;
        string check = PasswordCheck.text;
        if (pw != check)
        {
            SignMessage.text = "��й�ȣ�� ��ġ���� �ʽ��ϴ�.";
            return;
        }

        SignUpSuccess();
        SignMessage.text = "ȸ�������� �Ϸ�Ǿ����ϴ�.";
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
