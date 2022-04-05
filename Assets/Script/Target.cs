using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static System.Action target;

    private void Awake()
    {
        target = () => { Mission(); };
    }
    public void Mission()
    {
        Debug.Log("Mission Complete!!");
    }
}
