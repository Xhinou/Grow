﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : Event
{

    new void Start()
    {
        base.Start();
    }

    private void OnMouseDown()
    {
        flower.Feed(Flower.Need.Water, +1);
        //StartCoroutine(system.Timer(gameObject, 5));
    }
}
