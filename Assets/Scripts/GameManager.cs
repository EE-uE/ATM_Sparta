using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UserData userData;                               // ���� ����� ����
    public List<UserData> users = new List<UserData>();     // ���� ����� ����

    string userPath; // ����� ��� ���� ���, ���������� ���� path�� ����

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

    // ����� ��� �ҷ�����
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