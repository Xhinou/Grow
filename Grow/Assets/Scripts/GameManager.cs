using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Flower flower;
    [SerializeField] private int
        day,
        life,
        population,
        incDrunk,
        incDry,
        incShiny,
        modRes,
        muchWater;

    private void Start()
    {
        flower = GameObject.Find("Flower").GetComponent<Flower>();
        day = 1;
        population = 0;
        life = 0;
    }

    //Called when the Next Day button is pressed
    public void NextDay()
    {
        day += 1;
        //Play Day change Animation
        FoodMaths();
        CheckStates();
        SetNewDay();
        FlowerDeath();
    }

    //Calculations to compare Givens to (needed) Stats
    private void FoodMaths()
    {
        //Check the given Water
        if (flower._water == flower._baseWater)
        {
            modRes += 1;
        }
        else if (flower._water < flower._baseWater)
        {
            modRes -= 1;
            if (!flower._dry)
                incDry += 1;
        }
        else if (flower._water > flower._baseWater)
        {
            muchWater = flower._water - flower._baseWater;
            if (!flower._drunk)
            incDrunk += 1;
        }
        //Check the given Sun
        if (flower._sun == flower._baseSun)
        {
            modRes += 1;
            if (!flower._shiny)
                incShiny += 1;
        }
        else if (flower._sun < flower._baseSun)
        {
            flower._dirty = true;
            modRes -= 1;
        }
        else if (flower._sun >= 2 * flower._baseSun)
        {
            //Flower is dead
        }
    }

    //Timer to avoid events spam
    public IEnumerator Timer(GameObject obj, float seconds)
    {
        obj.GetComponent<BoxCollider2D>().enabled = false;
        //Play Disable Animation
        yield return new WaitForSeconds(seconds);
        //Play Enable Animation
        obj.GetComponent<BoxCollider2D>().enabled = true;
    }

    //Check if Population increment Life;
    public void Populate()
    {
        population += 1;
        if (population >= 10)
        {
            life += 1;
            population = 0;
        }
    }

    //Check if the Flower get a new State
    private void CheckStates()
    {
        if (incShiny >= 3)
        {
            flower._shiny = true;
            flower._res += 1;
            incShiny = 0;
        }
        if (incDrunk >= 3)
        {
            flower._drunk = true;
            flower._res -= 1;
            incDrunk = 0;
        }
        if (incDry >= 3)
        {
            flower._dry = true;
            flower._res -= 1;
            incDry = 0;
        }
    }

    private void SetNewDay()
    {
        flower._res = flower._baseRes + modRes;
        flower._sun = 0;
        flower._water = muchWater;
    }

    private void FlowerDeath()
    {
        int rand = Random.Range(0, 10) + 1;
        if (flower._res <= rand)
        {
            //Flower is alive
        } else
        {
            //Flower is dead
        }
    }

    //Properties
    public int _population { get { return population; } set { population = value; } }
}
