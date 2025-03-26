using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UserData userData;                               // 현재 사용자 정보
    public List<UserData> users = new List<UserData>();     // 여러 사용자 저장

    string userPath; // 사용자 목록 지정 경로, 여러명으로 인해 path는 삭제

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(Instance);
        }

        DontDestroyOnLoad(Instance);

        userPath = Path.Combine(Application.dataPath, "SaveData", "userData.json");
    }

    // 사용자 목록 불러오기
    public void LoadUsers()
    {
        if (!File.Exists(userPath))
        {
            return;
        }

        UserDataList userDataList = JsonUtilityManager.LoadUserDataList(userPath);

        if (userDataList == null)
        {
            return;
        }

        Debug.Log(PlayerPrefs.GetString("userid"));
        foreach (var user in userDataList.userDatas)
        {
            Debug.Log(user.UserID);
            if (PlayerPrefs.GetString("userid") == user.UserID)
            {
                userData = new UserData(user.UserID, user.Password, user.UserName, user.Balance, user.Cash);
            }
        }
    }
}