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
        incShiny;

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
        flower._sun = 0;
        flower._water = 0;
    }

    //Calculations to compare Givens to (needed) Stats
    private void FoodMaths()
    {
        //Check the given Water
        if (flower._water == flower._baseWater)
        {
            flower._res += 1;
        }
        else if (flower._water < flower._baseWater)
        {
            incShiny -= 1;
        }
        else if (flower._water > flower._baseWater)
        {
            int muchWater = flower._baseWater - flower._water;
        }
        //Check the given Sun
        if (flower._sun == flower._baseSun)
        {
            incShiny += 1;
        }
        else if (flower._sun < flower._baseSun)
        {
            incShiny -= 1;
        }
        else if (flower._sun > flower._baseSun)
        {

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
            incShiny = 0;
        }
    }

    //Properties
    public int _population { get { return population; } set { population = value; } }
}
