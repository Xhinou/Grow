using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Event[] events;

    private Flower flower;
    private Sun sun;

    [SerializeField]
    private int
        day,
        life,
        population;

    private void Start()
    {
        events = new Event[3];
        events = FindObjectsOfType<Event>();
        flower = GameObject.Find("Flower").GetComponent<Flower>();
        sun = GameObject.Find("Sun").GetComponent<Sun>();
        day = 1;
        population = 0;
        life = 0;
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
            life += 1;
            population = 0;
        }
    }

    // Change values for the new day
    private void SetNewDay()
    {
        foreach (Event e in events)
            e.OnNewDay();
        flower.res = flower.baseRes;
        flower.givenSun = 0;
        flower.givenWater = flower.muchWater;
        if (!flower.vegan)
            flower.givenMeat = 0;
        sun.incGiven = 0;
    }

    public int randDice(int dice)
    {
        int rand = Random.Range(0, dice) + 1;
        if (rand > dice)
            rand = dice;
        Debug.Log(rand + "/" + dice);
        return rand;
    }

    //Properties
    public int _population { get { return population; } set { population = value; } }
}
