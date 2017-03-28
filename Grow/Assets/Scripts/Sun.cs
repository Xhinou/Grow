using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : GameManager
{
    void Start()
    {

    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        flower.Sun += 1;
        StartCoroutine(Timer(gameObject, 5));
    }
}
