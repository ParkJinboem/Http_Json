//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Networking;




//public class RealTest2 : MonoBehaviour
//{
//    AppCheckRoot appState = new AppCheckRoot();

//    // Start is called before the first frame update
//    void Start()
//    {
//        StartCoroutine(ServerRequest());
//    }

//    IEnumerator ServerRequest()
//    {
//        WWWForm form = new WWWForm();
//        string url = "";
//        string id = "";
//        string pw = "";
//        form.AddField("Username", id);
//        form.AddField("Password", pw);


//        UnityWebRequest www = UnityWebRequest.Post(url, form);

//        yield return www.SendWebRequest();

//        if (www.error == null)
//        {
//            Debug.Log(www.downloadHandler.text);
//        }
//        else
//        {
//            Debug.Log("error");
//        }
//    }
//}
