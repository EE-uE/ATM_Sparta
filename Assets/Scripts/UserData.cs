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
        UserID = userID;        // 아이디
        Password = password;    // 비밀번호
        UserName = username;    // 이름
        Cash = cash;            // 현금
        Balance = balance;      // 잔고
        InLogin = false;        // 로그인되지 않음
    }
}

[System.Serializable]
public class UserDataList
{
    public List<UserData> userDatas = new List<UserData>();
}
