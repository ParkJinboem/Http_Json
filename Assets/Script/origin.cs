using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class origin : MonoBehaviour
{
    //1.�̱������� ����
    //2. �����ޱ�
    //3. Action ���
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        Target.target();
        target.GetComponent<Target>().Mission();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
