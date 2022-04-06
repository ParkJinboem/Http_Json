using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Https : MonoBehaviour
{
    public LoginData player1;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GetComponent<Json>().UserLoginData;

        StartCoroutine(WWWPOSTTEST());  //POST방식을 활용한 통신
    }
    IEnumerator WWWPOSTTEST()
    {
        WWWForm form = new WWWForm();

        string url = "--서버 주소를 입력--";
        string id = "admin";
        string pw = "--비밀번호--";
        form.AddField("Username", id);
        form.AddField("Password", pw);
        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return www.SendWebRequest();

        if (www.error == null)
        {
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            Debug.Log("error");
            

        }
    }
}
