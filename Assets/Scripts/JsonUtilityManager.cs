using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class JsonUtilityManager
{
    // Json 파일을 읽어 UserDataList 객채로 변환하는 메서드
    public static UserDataList LoadUserDataList(string filePath)
    {
        // 파일명이 존재하지 않으면 반환
        if (!File.Exists(filePath))
        {
            return null;
        }

        // 파일 내용을 Json으로 읽어옴
        string json = File.ReadAllText(filePath);
        // 메서드의 핵심, 변환
        UserDataList userDataList = JsonUtility.FromJson<UserDataList>(json);

        // 반환하여 원하는 곳에서 데이터를 사용 가능하게 함
        return userDataList;

        // 밑에 내용을 쓰기위한 메서드
        // string json = File.ReadAllText(userPath);
        // UserDataList userDataList = JsonUtility.FromJson<UserDataList>(json);
    }
}
