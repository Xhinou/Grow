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
        controller.Populate();
        //Play Bee Animation
        //Destroy(gameObject);
        print("Bee destroyed");
    }

    public override void OnNewDay()
    {

    }
}
