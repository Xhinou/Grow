using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroom : Event
{
    private new void Start()
    {
        base.Start();
    }

    private void OnMouseDown()
    {
        Poison();
    }

    public override void OnNewDay()
    {
        Destroy(gameObject);
    }

    private void Poison()
    {
        if (flower.infested)
        {
            flower.infested = false;
        }
        else
        {
            flower.poisoned = true;
        }
    }
}
