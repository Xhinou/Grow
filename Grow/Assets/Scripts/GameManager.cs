using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Flower flower;
    [SerializeField] private int
        day,
        life,
        population;

    private void Start()
    {
        flower = GameObject.Find("Flower").GetComponent<Flower>();
        day = 1;
        population = 0;
        life = 0;
        flower.res = flower.baseRes;
    }

    // Called when the Next Day button is pressed
    public void NextDay()
    {
        day += 1;
        //Play Day change Animation
        flower.flowerMaths();
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
    
    private void SetNewDay()
    {
        flower.res = flower.baseRes;
        flower.givenSun = 0;
        flower.givenWater = flower.muchWater;
        if (!flower.vegan)
            flower.givenMeat = 0;
    }

    //Properties
    public int _population { get { return population; } set { population = value; } }
}
