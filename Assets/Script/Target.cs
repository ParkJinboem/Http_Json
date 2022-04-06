using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //public static System.Action target;
    public int number1 = 10;
    public int number2 = 25;
    public int result;


    private void Awake()
    {
        //target = () => { Mission(); };
    }
    //public void Mission()
    //{
    //    Debug.Log("Mission Complete!!");
    //}

    public void plus(int num1, int num2)
    {
        result = num1 + num2;
    }
}
