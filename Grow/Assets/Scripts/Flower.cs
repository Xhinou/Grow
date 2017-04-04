using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    // Enums
    private enum Age { Young, Adult, Ancient };
    [SerializeField] private Age age;

    public enum Need { Meat, Sun, Water };
    private Need needs;

    private enum Health { Dying, Rotted, Bad, Neutral, Good, Excellent, Perfect };
    private Health health;

    // Stats
    [SerializeField] private int
        _baseMeat,
        _baseSun,
        _baseWater,
        _baseRes;

    [SerializeField] private bool
        _dirty,
        _drunk,
        _dry,
        _shiny,
        _vegan;

    // Givens
    [SerializeField] private int
        _givenMeat,
        _givenSun,
        _givenWater;

    // Others variables
    private int
        _res,
        incDrunk,
        incDry,
        incShiny,
        modRes,
        _newRes,
        muchWater;

    private void Start()
    {
        // Initialize default flower
        age = Age.Young;
        health = Health.Neutral;
        res = baseRes;
        DefaultStats();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DefaultStats();
        }
    }

    private void OnMouseDown()
    {
        /*
        Play Animation,
        Show needs
        */
    }

    // Setting default stats
    private void DefaultStats()
    {
        baseRes = 5;
        baseSun = RandDice(3);
        baseWater = RandDice(3);
        if (RandDice(20) == 1)
        {
            vegan = false;
            baseMeat = RandDice(3);
        }
        else
        {
            vegan = true;
            baseMeat = 0;
        }
    }

    // Called when the flower is growing up
    private void Evolve()//Age flowerAge)
    {
        if (age != Age.Ancient)
        {
            baseRes += 1;
            baseSun += RandDice(2);
            baseWater += RandDice(2);
            if (!vegan)
                baseMeat += 1;
            age += 1;
        }
        /*
        switch (flowerAge)
        {
            case Age.Young:
                baseRes += 1;
                baseSun += RandDice(2);
                baseWater += RandDice(2);
                if (!vegan)
                    baseFood += 1;
                age += 1;
                break;
            case Age.Adult:
                baseRes += 1;
                baseSun += RandDice(2);
                age += 1;
                break;
            case Age.Ancient:
                Debug.Log("Can't grow up anymore !");
                break;
            default:
                Debug.Log("Evolve : Age value error");
                break;
        }
        */
    }

    // Called to feed the Flower
    public void Feed(Need flowerNeed, int food)
    {
        switch (flowerNeed)
        {
            case Need.Meat:
                givenMeat += food;
                break;
            case Need.Sun:
                givenSun += food;
                break;
            case Need.Water:
                givenWater += food;
                break;
            default:
                Debug.Log("Feed() : Need value error");
                break;
        }
    }

    //Calculations to compare Givens to (needed) Stats
    public void CheckGivens()
    {
        //Check the given Water
        if (givenWater == baseWater)
        {
            res = ModRes(+1);
        }
        else if (givenWater < baseWater)
        {
            res = ModRes(-1);
            if (!dry)
                incDry += 1;
        }
        else if (givenWater > baseWater)
        {
            muchWater = givenWater - baseWater;
            if (!drunk)
                incDrunk += 1;
        }
        //Check the given Sun
        if (givenSun == baseSun)
        {
            res = ModRes(+1);
            if (!shiny)
                incShiny += 1;
        }
        else if (givenSun < baseSun)
        {
            dirty = true;
            res = ModRes(-1);
        }
        else if (givenSun >= 5 * baseSun)
        {
            //Flower is dead
        }
    }

    //Check if the Flower get a new State
    public void CheckStates()
    {
        if (incShiny >= 3)
        {
            shiny = true;
            res += 1;
            incShiny = 0;
        }
        if (incDrunk >= 3)
        {
            drunk = true;
            res -= 1;
            incDrunk = 0;
        }
        if (incDry >= 3)
        {
            dry = true;
            res -= 1;
            incDry = 0;
        }
    }

    private int ModRes(int mod)
    {
        int newRes = res + mod;
        return newRes;
    }

    public void Death()
    {
        int rand = Random.Range(0, 10) + 1;
        if (res <= rand)
        {
            //Flower is alive
        }
        else
        {
            //Flower is dead
        }
    }

    // Roll a dice and get the result
    private int RandDice(int dice)
    {
        int rand = Random.Range(0, dice) + 1;
        Debug.Log(rand + "/" + dice);
        return rand;
    }

    // Properties
    public int baseMeat { get { return _baseMeat; } set { _baseMeat = value; } } 
    public int baseSun { get { return _baseSun; } set { _baseSun = value; } }
    public int baseWater { get { return _baseWater; } set { _baseWater = value; } }
    public int baseRes { get { return _baseRes; } set { _baseRes = value; } }
    public int res { get { return _res; } set { _res = value; } }
    public int newRes { get { return _newRes; } set { _newRes = value; } }
    public bool dirty { get { return _dirty; } set { _dirty = value; } }
    public bool drunk { get { return _drunk; } set { _drunk = value; } }
    public bool dry { get { return _dry; } set { _dry = value; } }
    public bool shiny { get { return _shiny; } set { _shiny = value; } }
    public bool vegan { get { return _vegan; } set { _vegan = value; } }
    public int givenMeat { get { return _givenMeat; } set { _givenMeat = value; } }
    public int givenSun { get { return _givenSun; } set { _givenSun = value; } }
    public int givenWater { get { return _givenWater; } set { _givenWater = value; } }
}