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
        shinyInc;

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
    }

    //Calculations to compare Givens to (needed) Stats
    private void FoodMaths()
    {
        if (flower._water == flower._baseWater)
        {
            shinyInc += 1;
        }
        else if (flower._water < flower._baseWater)
        {
            shinyInc -= 1;
        }
        else if (flower._water > flower._baseWater)
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
    public void CheckPop()
    {
        if (population >= 10)
        {
            life += 1;
            population = 0;
        }
    }

    //Check if the Flower get a new State
    private void CheckStates()
    {
        if (shinyInc >= 3)
        {
            flower._shiny = true;
            shinyInc = 0;
        }
    }

    //Constructors
    public int _population { get { return population; } set { population = value; } }
}
