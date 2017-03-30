using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : Event
{

    new void Start()
    {
        base.Start();
    }

    private void OnMouseDown()
    {
        system.Populate();
        //Play Bee Animation
        //Destroy(gameObject);
        print("Bee destroyed");
    }
}
