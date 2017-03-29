﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    protected GameManager system;
    protected Flower flower;

    private float delay;

    protected void Start()
    {
        system = GameObject.Find("System").GetComponent<GameManager>();
        flower = GameObject.Find("Flower").GetComponent<Flower>();
    }

    protected void OnMouseEnter()
    {
        Debug.Log("Interaction : " + gameObject.name);
    }
}
