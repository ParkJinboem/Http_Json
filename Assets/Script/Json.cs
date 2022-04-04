using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoginData
{
    public string ID = "111";
    public string PW = "222";
    public int Version = 1;
}

public class Json : MonoBehaviour
{
    public static Json instance;     //ΩÃ±€≈Ê

    public LoginData UserLoginData = new LoginData();

    string path;
    string data;

    private void Awake()
    {
        #region ΩÃ±€≈Ê
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        #endregion
        
        path = Application.dataPath + "/TestJson.json"; //¿˙¿Â∞Ê∑Œ
    }

    [ContextMenu("SaveData")]
    public void SaveData()
    {
        data = JsonUtility.ToJson(UserLoginData);
        File.WriteAllText(path, data);
    }

    [ContextMenu("LoadData")]
    public void LoadData()
    {
        data = File.ReadAllText(path);
        UserLoginData = JsonUtility.FromJson<LoginData>(data);
    }
}
