using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

[System.Serializable]
public class ServerInfo
{
    public string serverId;
    public string serverName;
}

[System.Serializable]
public class ServerRoot
{
    public List<ServerInfo> rows;
    
}


public class Server : MonoBehaviour
{

    public Dropdown serverList;
    public Text selectedServerName;
    string serverid = "";
    string characterName = "";
    public InputField inputText;


    ServerRoot serverData = new ServerRoot();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ServerRequest());
    }

    public void CharacterSearch()
    {
        string temp = selectedServerName.text;
        serverid = serverData.rows.Find(x => x.serverName == temp).serverId;
  
        characterName = UnityWebRequest.EscapeURL(inputText.text);  //ÀÎÄÚµù
        StartCoroutine(CharacterRequest(serverid, characterName));

    }

    IEnumerator CharacterRequest(string serverId, string characterName)
    {
        string url = $"https://api.neople.co.kr/df/servers/{serverId}/characters?characterName={characterName}&apikey=3xM8efKmlbfGJu8Efj3SUtBkIuiinRxV";
        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        if(www.error == null)
        {
            print(www.downloadHandler.text);
        }
        else
        {
            Debug.Log(www.error);
        }
       
    }

  
    IEnumerator ServerRequest()
    {
        string url = "https://api.neople.co.kr/df/servers?apikey=3xM8efKmlbfGJu8Efj3SUtBkIuiinRxV";
        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        if(www.error ==null)
        {
            Debug.Log(www.downloadHandler.text);    //Á¦ÀÌ½¼ÀÌ ³¯¶ó¿È

            serverData = JsonUtility.FromJson<ServerRoot>(www.downloadHandler.text);

            foreach(var item in serverData.rows)
            {
                Dropdown.OptionData option = new Dropdown.OptionData();
                option.text = item.serverName;

                serverList.options.Add(option);
            }
        }
        else 
        {
            Debug.Log("Error");
        }
    }
}
