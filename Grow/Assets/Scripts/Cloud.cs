using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : Event
{
    /*private GameManager system;
     private Flower flower;

     public Flower Flow
     {
         get { return Flow; }
         set { Flow = value; }
     }*/
    //GameManager system;

     new private void Start()
    {
        base.Start();
    }

    private void OnMouseDown()
    {
        flower.Feed(Flower.Need.Water, +1);
        StartCoroutine(system.Timer(gameObject, 5));
    }
}
