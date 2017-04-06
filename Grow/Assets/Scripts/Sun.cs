using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : Event
{
    private int incGiven;

    new void Start()
    {
        base.Start();
        incGiven = 0;
    }

    private void OnMouseDown()
    {
        flower.Feed(Flower.Need.Sun, +1);
        SteamOut();
        StartCoroutine(system.Timer(gameObject, 5));
    }

    private void SteamOut()
    {
        incGiven += 1;
        if (incGiven >= 2)
        {
            flower.Feed(Flower.Need.Water, -1);
            incGiven = 0;
        }
    }
}
