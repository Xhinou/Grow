using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : Grow
{
    protected GameManager gameManager;
    protected Flower flower;

    public Vector2 spawn;
    
    protected void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        flower = FindObjectOfType<Flower>();
    }

    public virtual void OnNewDay() {

    }
}
