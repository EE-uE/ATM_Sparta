using System.IO;
using UnityEngine;


public class SaveManager : MonoBehaviour
{
    public static string path = Path.Combine(Application.dataPath, "SaveData", "userData.json");

    // 유저 데이터 저장
    public static void SaveUserData(UserData userData)
    {
        string json = File.ReadAllText(path);
        UserDataList userDataList = JsonUtility.FromJson<UserDataList>(json);

        foreach (var user in userDataList.userDatas)
        {
            if (PlayerPrefs.GetString("userid") == user.UserID)
            {
                user.UserID = GameManager.Instance.userData.UserID;
                user.Password = GameManager.Instance.userData.Password;
                user.UserName = GameManager.Instance.userData.UserName;
                user.Balance = GameManager.Instance.userData.Balance;
                user.Cash = GameManager.Instance.userData.Cash;
            }
        }
        string data = JsonUtility.ToJson(userDataList, true); // JSON 보기 쉽게 저장
        File.WriteAllText(path, data);
    }
}
