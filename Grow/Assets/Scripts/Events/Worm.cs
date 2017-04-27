using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : Event
{
    private bool isAlive;

    new void Start()
    {
        base.Start();
        isAlive = true;
    }

    private void OnMouseDown()
    {
        // Kill the worm
        Destroy(gameObject);
    }

    public override void OnNewDay()
    {
        base.OnNewDay();

    }
}
