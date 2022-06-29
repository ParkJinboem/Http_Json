using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServiceCheck : MonoBehaviour
{
    //public GameObject Json;
    public string app_verstion = JsonData.instance.GetComponent<AppCheck>().app_version;
    public string app_down = JsonData.instance.GetComponent<AppCheck>().app_down;
    public string service_message = JsonData.instance.GetComponent<AppCheck>().service_message;
    public int result = JsonData.instance.GetComponent<AppCheck>().result;
    public int service_state = JsonData.instance.GetComponent<AppCheck>().service_state;

    public string app_Newestversion;
    public string app_Download;
    public int app_Nomalstate;

    AppCheckRoot appData = new AppCheckRoot();

    // Start is called before the first frame update
    void Awake()
    {
        print(app_verstion);
        print(app_down);
        print(service_message);

        StartCoroutine(Load_Appcheck());
    }

    IEnumerator Load_Appcheck()
    {
        WWWForm form = new WWWForm();
        string url = "";
        int result;
        int service_state;
        string app_verstion = "";
        string app_down = "";
        string service_message = "";

        form.AddField("AppVersion", app_verstion);//보내는것.
        form.AddField("AppDown", app_down);
        form.AddField("ServiceMessage", service_message);


        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return www.SendWebRequest();

        if (www.error == null)
        {
            appData = JsonUtility.FromJson<AppCheckRoot>(www.downloadHandler.text);
            string app_version = appData.rows.Find(x => x.app_version == app_Newestversion).app_version;
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            Debug.Log("error");
        }

    }
}
