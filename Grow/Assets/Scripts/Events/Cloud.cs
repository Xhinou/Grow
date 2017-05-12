using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : Event
{

    private new void Start()
    {
        base.Start();
    }

    private void OnMouseDown()
    {
        flower.Feed(Flower.Need.Water, +1);
        //StartCoroutine(system.Timer(gameObject, 5));
    }

    public override void OnNewDay()
    {
        
    }
}
