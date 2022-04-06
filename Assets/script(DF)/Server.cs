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

//=====================================
[System.Serializable]
public class CharacterInfo
{
    public string serverId;
    public string characterId;
    public string characterName;
    public int level;
    public string jobId;
    public string jobGrowId;
    public string jobName;
    public string jobGrowName;
}
[System.Serializable]
public class CharacterRoot
{
    public List<CharacterInfo> rows;
}

//========================================================


public class Server : MonoBehaviour
{

    public Dropdown serverList;
    public Text selectedServerName;
    string serverid = "";
    string characterName = "";
    string characterId = "";
    public InputField inputText;
    public RawImage img;


    ServerRoot serverData = new ServerRoot();
    CharacterRoot characterData = new CharacterRoot();
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

    IEnumerator CharaterImageRequest(string serverId, string characterId)
    {
        string url = $"https://img-api.neople.co.kr/df/servers/{serverId}/characters/{characterId}?zoom=1";
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);

        yield return www.SendWebRequest();

        if (www.error == null)
        {
            img.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
        else
        {
            Debug.Log(www.error);
        }
    }

    IEnumerator CharacterRequest(string serverId, string characterName)
    {
        string url = $"https://api.neople.co.kr/df/servers/{serverId}/characters?characterName={characterName}&apikey=3xM8efKmlbfGJu8Efj3SUtBkIuiinRxV";
        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        if (www.error == null)
        {
            print(www.downloadHandler.text);
            characterData = JsonUtility.FromJson<CharacterRoot>(www.downloadHandler.text);
            characterId = characterData.rows.Find(x => x.characterName == inputText.text).characterId;

            StartCoroutine(CharaterImageRequest(serverId, characterId));
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

        if (www.error == null)
        {
            Debug.Log(www.downloadHandler.text);    //Á¦ÀÌ½¼ÀÌ ³¯¶ó¿È

            serverData = JsonUtility.FromJson<ServerRoot>(www.downloadHandler.text);

            foreach (var item in serverData.rows)
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
