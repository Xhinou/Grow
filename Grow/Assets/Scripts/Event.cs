using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : GameManager
{
    protected Controller controller;
    protected Flower flower;
    
    protected void Start()
    {
        controller = FindObjectOfType<Controller>();
        flower = FindObjectOfType<Flower>();
    }

    protected void OnMouseEnter()
    {

    }

    public virtual void OnNewDay()
    {
        PopWorm();
    }

    private void PopWorm()
    {
        Instantiate(events.worm);
        Instantiate(events.worm, new Vector3(0, 0, 0), Quaternion.identity);
        if (randDice(16) == 16 - ((int)flower.age * 2))
        {
            // Create a worm
        }
    }
}
