using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class JsonUtilityManager
{
    // Json ������ �о� UserDataList ��ä�� ��ȯ�ϴ� �޼���
    public static UserDataList LoadUserDataList(string filePath)
    {
        // ���ϸ��� �������� ������ ��ȯ
        if (!File.Exists(filePath))
        {
            return null;
        }

        // ���� ������ Json���� �о��
        string json = File.ReadAllText(filePath);
        // �޼����� �ٽ�, ��ȯ
        UserDataList userDataList = JsonUtility.FromJson<UserDataList>(json);

        // ��ȯ�Ͽ� ���ϴ� ������ �����͸� ��� �����ϰ� ��
        return userDataList;

        // �ؿ� ������ �������� �޼���
        // string json = File.ReadAllText(userPath);
        // UserDataList userDataList = JsonUtility.FromJson<UserDataList>(json);
    }
}
