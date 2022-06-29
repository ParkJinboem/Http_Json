//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.Networking;






//public class RealTest : MonoBehaviour
//{
//    public InputField selectedUser_id;
//    public InputField selectedUser_pass;

//    string user_ID = "";
//    string user_PASS = "";

//    UserRoot userData = new UserRoot();
//    // Start is called before the first frame update
//    void Start()
//    {
//        StartCoroutine(ServerRequest());
//    }
    
//    public void UserIdSearch()
//    {
//        string temp = selectedUser_id.text;
//        user_ID = userData.rows.Find(x => x.user_id == temp).user_id;

//        user_ID = UnityWebRequest.EscapeURL(selectedUser_id.text);

//    }
//    public void UserPassSearch()
//    {
//        string temp = selectedUser_pass.text;
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
//            userData = JsonUtility.FromJson<UserRoot>(www.downloadHandler.text);
//            Debug.Log(www.downloadHandler.text);
//        }
//        else
//        {
//            Debug.Log("error");
//        }
//    }
//}
