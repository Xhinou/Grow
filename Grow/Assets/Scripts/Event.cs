using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : GameManager
{
    protected Controller controller;
    protected Flower flower;

    public Vector2 spawn;
    
    protected void Start()
    {
        controller = FindObjectOfType<Controller>();
        flower = FindObjectOfType<Flower>();
    }

    public virtual void OnNewDay() {

    }
}
