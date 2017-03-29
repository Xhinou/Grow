using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : Event
{

    new void Start()
    {
        base.Start();
    }

    private void OnMouseDown()
    {
        flower.Feed(Flower.Need.Sun, +1);
        StartCoroutine(system.Timer(gameObject, 5));
    }
}
