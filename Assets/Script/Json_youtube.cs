using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. ������(�ڵ� = Ŭ����)�� ��������. => ������ ������ ����
// 2. �� �����͸� Json���� ��ȯ.

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
    Data player = new Data() { nickname = "���� �ڵ�", level = 50, coin= 200, skill= false};
    // Start is called before the first frame update
    void Start()
    {
        //2.json ��ȯ
        string jsonData = JsonUtility.ToJson(player);

        Data player2 = JsonUtility.FromJson<Data>(jsonData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
