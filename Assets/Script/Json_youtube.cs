using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. 데이터(코드 = 클래스)를 만들어야함. => 저장할 데이터 생성
// 2. 그 데이터를 Json으로 변환.

class Data
{
    public string nickname;
    public int level;
    public int coin;
    public bool skill;
    // etc...
}



public class Json_youtube : MonoBehaviour
{
    Data player = new Data() { nickname = "나도 코딩", level = 50, coin= 200, skill= false};
    // Start is called before the first frame update
    void Start()
    {
        //2.json 변환
        string jsonData = JsonUtility.ToJson(player);

        Data player2 = JsonUtility.FromJson<Data>(jsonData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
