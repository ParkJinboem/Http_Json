using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class origin : MonoBehaviour
{
    //1.싱글톤으로 변경
    //2. 직접받기
    //3. Action 사용
    public GameObject target;
    public Target num;
    

    // Start is called before the first frame update
    void Start()
    {
        //Target.target();
        //target.GetComponent<Target>().Mission();
        num = target.GetComponent<Target>();

        target.GetComponent<Target>().plus(num.number1, num.number2);
        Debug.Log(num.result);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
