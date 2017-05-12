using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : GameManager
{
    // Enums
    public enum Age { Young, Adult, Ancient };
    public Age age;

    private enum Health { Dying = -3, Rotted = -2, Bad = -1, Neutral = 0, Good = 1, Excellent = 2, Perfect = 3 };
    [SerializeField] private Health health;

    public enum Need { Meat, Sun, Water };
    private Need needs;

    // All calculations to determine the resistance of the Flower
    public delegate void FlowerMaths();
    public FlowerMaths flowerMaths;

    // Stats
    [SerializeField] private int
        _baseMeat,
        _baseSun,
        _baseWater,
        _baseRes;

    [SerializeField] private bool
        _dirty = false,
        _dead = false,
        _drunk = false,
        _dry = false,
        _infested = false,
        _poisoned = false,
        _shiny = false,
        _vegan;

    // Givens
    [SerializeField] private int
        _givenMeat,
        _givenSun,
        _givenWater;

    // Others variables
    [SerializeField]
    private int
        _res,
        incDrunk = 0,
        incDry = 0,
        incShiny = 0,
        decDrunk,
        _newRes,
        _muchWater = 0,
        healthState = 0, // Health states : -1 = Minimal; 0 = Neutral; 1 = Maximal (health)
        survivance = 0; // Day passed in a non-zero health state : -3 = Death; 3 = Evolve;

    private void Start()
    {
        AddDelegates();
        // Initialize default flower
        age = Age.Young;
        health = Health.Neutral;
        res = baseRes;
        DefaultStats(age);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DefaultStats(age);
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
    private void DefaultStats(Age flowerAge)
    {
        if (flowerAge == Age.Young)
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
        else
        {
            DefaultStats(age - 1);
            baseRes += 1;
            baseSun += randDice(2);
            baseWater += randDice(2);
            if (!vegan)
                baseMeat += 1;
        }
    }

    // Called when the flower is growing up
    private void Evolve()
    {
        if (age == Age.Ancient)
        {
            Debug.Log("Can't grow up anymore !");
            return;
        }
        baseRes += 1;
        baseSun += randDice(2);
        baseWater += randDice(2);
        if (!vegan)
            baseMeat += 1;
        age += 1;
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

    // Add methods to delegate methods
    private void AddDelegates()
    {
        flowerMaths += CheckGivens;
        flowerMaths += CheckIncrement;
        flowerMaths += CheckStates;
        flowerMaths += CheckHealth;
        flowerMaths += Survive;
    }

    // Calculations to compare Givens to (needed) Stats
    private void CheckGivens()
    {
        // Check the given Water
        if (givenWater == baseWater)
        {
            muchWater = 0;
            res += 1;
            if (dry)
                dry = false;
        }
        else if (givenWater < baseWater)
        {
            muchWater = 0;
            res -= 1;
            if (!dry)
                incDry += 1;
        }
        else if (givenWater > baseWater)
        {
            muchWater = givenWater - baseWater;
            if (!drunk)
                incDrunk += 1;
            if (dry)
                dry = false;
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
            if (shiny)
                shiny = false;
        }
        else if (givenSun >= baseSun + 5)
        {
            //Flower is dead
        }
        else
        {
            if (shiny)
                shiny = false;
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
            res += 1;
        if (muchWater == 0)
            drunk = false;
        if (drunk)
            res -= 1;
        if (dry)
            res -= 1;
    }

    private int ModRes(int mod)
    {
        newRes = res + mod;
        return newRes;
    }

    // Check the Health of the Flower
    private void CheckHealth()
    {
        if (res >= randDice(10))
        {
            if (healthState != 1)
            {
                health += 1;
                survivance = 0;
            }
            else
                survivance += 1;
        }
        else
        {
            if (healthState != -1)
            {
                health -= 1;
                survivance = 0;
            } 
            else
                survivance -= 1;
        }
        switch (age)
        {
            case Age.Young:
                if (health == Health.Good)
                    healthState = 1;
                else if (health == Health.Bad)
                    healthState = -1;
                else
                    healthState = 0;
                break;
            case Age.Adult:
                if (health == Health.Excellent)
                    healthState = 1;
                else if (health == Health.Rotted)
                    healthState = -1;
                else
                    healthState = 0;
                break;
            case Age.Ancient:
                if (health == Health.Perfect)
                    healthState = 1;
                else if (health == Health.Dying)
                    healthState = -1;
                else
                    healthState = 0;
                break;
            default:
                Debug.Log("CheckHealth() : Error in Flower Age");
                break;
        }
    }

    // Check if the Flower is still alive
    private void Survive()
    {
        if (survivance >= 3)
        {
            Evolve();
            survivance = 0;
        }
        else if (survivance <= -3)
        {
            dead = true;
            Debug.Log("Game Over : The Flower is dead");
        }
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
    public bool infested { get { return _infested; } set { _infested = value; } }
    public bool poisoned { get { return _poisoned; } set { _poisoned = value; } }
    public bool shiny { get { return _shiny; } set { _shiny = value; } }
    public bool vegan { get { return _vegan; } set { _vegan = value; } }
    public int givenMeat { get { return _givenMeat; } set { _givenMeat = value; } }
    public int givenSun { get { return _givenSun; } set { _givenSun = value; } }
    public int givenWater { get { return _givenWater; } set { _givenWater = value; } }
}