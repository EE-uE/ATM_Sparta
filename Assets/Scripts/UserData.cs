using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class UserData
{
    public string UserID;
    public string Password;
    public string UserName;
    public int Balance;
    public int Cash;
    public bool InLogin;

    public UserData(string userID, string password, string username, int balance, int cash)
    {
        UserID = userID;        // ���̵�
        Password = password;    // ��й�ȣ
        UserName = username;    // �̸�
        Cash = cash;            // ����
        Balance = balance;      // �ܰ�
        InLogin = false;        // �α��ε��� ����
    }
}

[System.Serializable]
public class UserDataList
{
    public List<UserData> userDatas = new List<UserData>();
}
