using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : GameManager
{

    void Start()
    {

    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        flower.water += 1;
        StartCoroutine(Timer(gameObject, 5));
    }
}
