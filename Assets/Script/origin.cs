using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class origin : MonoBehaviour
{
    //1.싱글톤으로 변경
    //2. 직접받기
    //3. Action 사용
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
