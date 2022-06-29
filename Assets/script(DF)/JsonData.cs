using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//Input
[System.Serializable]
public class UserInfo
{
    public string user_id;
    public string user_pass;
    public string user_nick;
    public string user_phone;
}
[System.Serializable]
public class UserRoot
{
    public List<UserInfo> rows;     //객체처리
}

//Output
[System.Serializable]
public class AppCheck
{
    public int result;
    public int service_state;
    public string app_version = "1";
    public string app_down = "2";
    public string service_message = "3";

}
[System.Serializable]
public class AppCheckRoot
{
    public List<AppCheck> rows;
}

public class JsonData : MonoBehaviour
{
    public static JsonData instance;
    //public AppCheckRoot appState = new AppCheckRoot();
    //public UserRoot userInfo = new UserRoot();

    //string path;
    //string appData;
    //string userData;

    private void Awake()
    {
        #region 싱글톤
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        #endregion

        //path = Application.dataPath + "/TestJson.json"; //저장경로
    }

    ////앱데이터 저장 및 로드
    //[ContextMenu("AppSaveData")]
    //public void AppSaveData()
    //{
    //    appData = JsonUtility.ToJson(appState);
    //    File.WriteAllText(path, appData);
    //}

    //[ContextMenu("AppLoadData")]
    //public void AppLoadData()
    //{
    //    appData = File.ReadAllText(path);
    //    appState = JsonUtility.FromJson<AppCheckRoot>(appData);
    //}

    ////유저 데이터 저장 및 로드
    //[ContextMenu("UserDataSaveData")]
    //public void UserDataSaveData()
    //{
    //    userData = JsonUtility.ToJson(userInfo);
    //    File.WriteAllText(path, userData);
    //}

    //[ContextMenu("UserDataLoadData")]
    //public void UserDataLoadData()
    //{
    //    userData = File.ReadAllText(path);
    //    userInfo = JsonUtility.FromJson<UserRoot>(userData);
    //}

}

