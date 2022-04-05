using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkTest_youtube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UnityWebRequestGet());
    }
    
    IEnumerator UnityWebRequestGet()
    {
        string url = "API 사이트";    //통신을할 주소

        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();
    }
}
