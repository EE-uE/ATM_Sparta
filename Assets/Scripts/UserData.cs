using System.Collections.Generic;

[System.Serializable]
public class UserData
{
    public string UserID;
    public string Password;
    public string UserName;
    public int Balance;
    public int Cash;

    public UserData(string userID, string password, string username, int balance, int cash)
    {
        UserID = userID;        // ���̵�
        Password = password;    // ��й�ȣ
        UserName = username;    // �̸�
        Cash = cash;            // ����
        Balance = balance;      // �ܰ�
    }
}

[System.Serializable]
public class UserDataList
{
    public List<UserData> userDatas = new List<UserData>();
}
