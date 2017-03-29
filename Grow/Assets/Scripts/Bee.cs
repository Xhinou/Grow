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
        system._population += 1;
        system.CheckPop();
        //Play Bee Animation
        //Destroy(gameObject);
    }
}
