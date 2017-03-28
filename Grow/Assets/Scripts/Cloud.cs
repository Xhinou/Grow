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
    Flower flower;
    GameManager system;
    void Start()
    {
        system = GameObject.Find("System").GetComponent<GameManager>();
        flower = GameObject.Find("Flower").GetComponent<Flower>();
    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        flower.Feed(Water, 1);
        StartCoroutine(system.Timer(gameObject, 5));
    }
}
