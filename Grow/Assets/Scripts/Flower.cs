using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    // Enums
    private enum Age { Young, Adult, Ancient };
    [SerializeField] private Age age;

    public enum Need { Food, Sun, Water };
    private Need needs;

    // Stats
    [SerializeField] private int
        _baseFood,
        _baseSun,
        _baseWater,
        _baseRes,
        _res;
    [SerializeField] private bool
        _dirty,
        _drunk,
        _dry,
        _shiny,
        _vegan;

    // Givens
    [SerializeField] private int
        _givenFood,
        _givenSun,
        _givenWater;

    // Others variables
    private int rand;

    private void Start()
    {
        // Initialize default flower
        age = Age.Young;
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
            baseFood = RandDice(3);
        }
        else
        {
            vegan = true;
            baseFood = 0;
        }
    }

    // Called when the flower is growing up
    private void Evolve(Age flowerAge)
    {
        switch (flowerAge)
        {
            case Age.Young:
                ModRes(+1);
                break;
            case Age.Adult:
                ModRes(+1);
                break;
            case Age.Ancient:
                Debug.Log("Can't grow up anymore !");
                break;
            default:
                Debug.Log("Evolve : Age value error");
                break;
        }
    }

    // Called to feed the Flower
    public void Feed(Need flowerNeed, int mod)
    {
        switch (flowerNeed)
        {
            case Need.Food:
                food += mod;
                break;
            case Need.Sun:
                sun += mod;
                break;
            case Need.Water:
                water += mod;
                break;
            default:
                Debug.Log("Feed : Need value error");
                break;
        }
    }

    public void CheckGivens()
    {

    }

    // Roll a dice and get the result
    private int RandDice(int dice)
    {
        rand = Random.Range(0, dice) + 1;
        Debug.Log(rand + "/" + dice);
        return rand;
    }

    // Called to modify the Resistance of the Flower
    private void ModRes(int mod)
    {
        baseRes += mod;
    }

    // Properties
    public int baseFood { get { return _baseFood; } set { _baseFood = value; } } 
    public int baseSun { get { return _baseSun; } set { _baseSun = value; } }
    public int baseWater { get { return _baseWater; } set { _baseWater = value; } }
    public int baseRes { get { return _baseRes; } set { _baseRes = value; } }
    public int res { get { return _res; } set { _res = value; } }
    public bool dirty { get { return _dirty; } set { _dirty = value; } }
    public bool drunk { get { return _drunk; } set { _drunk = value; } }
    public bool dry { get { return _dry; } set { _dry = value; } }
    public bool shiny { get { return _shiny; } set { _shiny = value; } }
    public bool vegan { get { return _vegan; } set { _vegan = value; } }
    public int givenFood { get { return _givenFood; } set { _givenFood = value; } }
    public int givenSun { get { return _givenSun; } set { _givenSun = value; } }
    public int givenWater { get { return _givenWater; } set { _givenWater = value; } }
}