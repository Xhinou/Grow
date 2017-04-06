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
        _dead,
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
        _muchWater;

    GameManager system;

    private void Start()
    {
        // Set the classes
        system = GameObject.Find("System").GetComponent<GameManager>();

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
        baseSun = randDice(3);
        baseWater = randDice(3);
        if (randDice(20) == 1)
        {
            vegan = false;
            baseMeat = randDice(3);
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
            baseSun += randDice(2);
            baseWater += randDice(2);
            if (!vegan)
                baseMeat += 1;
            age += 1;
        } else
        {
            Debug.Log("Can't grow up anymore !");
        }
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

    // All calculations to determine the resistance of the Flower
    public void FoodMaths()
    {
        CheckGivens();
        CheckIncrement();
        CheckStates();
    }

    // Calculations to compare Givens to (needed) Stats
    private void CheckGivens()
    {
        // Check the given Water
        if (givenWater == baseWater)
        {
            res += 1;
        }
        else if (givenWater < baseWater)
        {
            res -= 1;
            if (!dry)
                incDry += 1;
        }
        else if (givenWater > baseWater)
        {
            _muchWater = givenWater - baseWater;
            if (!drunk)
                incDrunk += 1;
        }
        // Check the given Sun
        if (givenSun == baseSun)
        {
            res += 1;
            if (!shiny)
                incShiny += 1;
        }
        else if (givenSun < baseSun)
        {
            if (age == Age.Ancient)
                res -= 2;
            else
                res -= 1;
        }
        else if (givenSun >= baseSun + 5)
        {
            //Flower is dead
        }
    }

    // Check if the Flower get a new State
    private void CheckIncrement()
    {
        if (incShiny >= 3)
        {
            shiny = true;
            incShiny = 0;
        }
        if (incDrunk >= 3)
        {
            drunk = true;
            incDrunk = 0;
        }
        if (incDry >= 3)
        {
            dry = true;
            incDry = 0;
        }
    }

    // Get the new resistance of the Flower
    private void CheckStates()
    {
        if (shiny)
        {
            res += 1;
        }
        if (drunk)
        {
            res -= 1;
        }
        if (dry)
        {
            res -= 1;
        }
    }

    private int ModRes(int mod)
    {
        newRes = res + mod;
        return newRes;
    }

    // Check if the Flower is still alive
    public void Survive()
    {
        if (res <= randDice(10))
        {
            //Flower is alive
        }
        else
        {
            if (life)
            //Flower is dead
        }
    }

    // Roll a dice and return the result
    private int randDice(int dice)
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
    public int muchWater { get { return _muchWater; } set { _muchWater = value; } }
    public bool dirty { get { return _dirty; } set { _dirty = value; } }
    public bool dead { get { return _dead; } set { _dead = value; } }
    public bool drunk { get { return _drunk; } set { _drunk = value; } }
    public bool dry { get { return _dry; } set { _dry = value; } }
    public bool shiny { get { return _shiny; } set { _shiny = value; } }
    public bool vegan { get { return _vegan; } set { _vegan = value; } }
    public int givenMeat { get { return _givenMeat; } set { _givenMeat = value; } }
    public int givenSun { get { return _givenSun; } set { _givenSun = value; } }
    public int givenWater { get { return _givenWater; } set { _givenWater = value; } }
}