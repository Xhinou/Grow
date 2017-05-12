using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : GameManager
{
    private EventsLoader eventsLoader;
    private Flower flower;
    private Sun sun;

    public int
        day,
        population,
        extraLife;

    private void Start()
    {
        eventsLoader = gameObject.GetComponent<EventsLoader>();
        flower = GameObject.FindWithTag("Flower").GetComponent<Flower>();
        sun = eventsLoader.sun.GetComponent<Sun>();
        day = 1;
        population = 0;
        extraLife = 0;
        flower.res = flower.baseRes;
    }

    // Called when the Next Day button is pressed
    public void NextDay()
    {
        day += 1;
        flower.flowerMaths();
        //Play Day change Animation
        SetNewDay();
    }

    // Timer to avoid events spam
    public IEnumerator Timer(GameObject obj, float seconds)
    {
        obj.GetComponent<BoxCollider2D>().enabled = false;
        //Play Disable Animation
        yield return new WaitForSeconds(seconds);
        //Play Enable Animation
        obj.GetComponent<BoxCollider2D>().enabled = true;
    }

    // Check if Population increment Life;
    public void Populate()
    {
        population += 1;
        if (population >= 10)
        {
            extraLife += 1;
            population = 0;
        }
    }

    // Change values for the new day
    private void SetNewDay()
    {
        Event[] myEvents = FindObjectsOfType<Event>();
        foreach (Event e in myEvents)
            e.OnNewDay();
        InstantiateNewEvents();
        flower.res = flower.baseRes;
        flower.givenSun = 0;
        flower.givenWater = flower.muchWater;
        if (!flower.vegan)
            flower.givenMeat = 0;
        sun.incGiven = 0;
    }

    private void InstantiateNewEvents()
    {
        if (randDice(16) >= 16 - ((int)flower.age * 2))
        {
            eventsLoader.LoadEvent(eventsLoader.worm);
        }
        if (randDice(25) == 25)
        {
            eventsLoader.LoadEvent(eventsLoader.bee);
        }
    }

    //Properties
    public int _population { get { return population; } set { population = value; } }
}
