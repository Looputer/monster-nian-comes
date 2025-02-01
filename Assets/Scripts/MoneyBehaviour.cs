using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBehaviour : MonoBehaviour
{
    public float onscreenTime = 3f;
    void Start()
    {
        Destroy(gameObject, onscreenTime);    
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "年兽")
        {
            Destroy(gameObject);
        }
    }
}
