using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    //Enums
    private enum Age {Young, Adult, Ancient};
    [SerializeField] private Age age;

    public enum Need { Food, Sun, Water };
    private Need needs;

    //Stats
    [SerializeField] private int
        baseFood,
        baseSun,
        baseWater,
        baseRes,
        res;
    [SerializeField] private bool
        drunk,
        shiny,
        vegan;

    //Givens
    [SerializeField] private int
        food,
        sun,
        water;

    //Others variables
    private int rand;

    private void Start()
    {
        //Initialize default flower
        age = Age.Young;
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

    //Setting default stats
    private void DefaultStats(Age flowerAge)
    {
        baseRes = 5;
        RandDice(5);
        baseSun = rand;
        RandDice(5);
        baseWater = rand;
        RandDice(20);
        if (rand == 1)
        {
            vegan = false;
            RandDice(3);
            baseFood = rand;
        }
        else
        {
            vegan = true;
            baseFood = 0;
        }
    }

    //Called when the flower is growing up
    private void Evolve(Age flowerAge)
    {
        switch (flowerAge) {
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

    //Called to feed the Flower
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

    //Roll a dice and get the result
    private void RandDice(int dice)
    {
        rand = Random.Range(0, dice) + 1;
        Debug.Log(rand + "/" + dice);
    }

    //Called to modify the Resistance of the Flower
    private void ModRes(int mod)
    {
        baseRes += mod;
    }

    //Properties
    public int _baseFood { get { return baseFood; } set { baseFood = value; } } 
    public int _baseSun { get { return baseSun; } set { baseSun = value; } }
    public int _baseWater { get { return baseWater; } set { baseWater = value; } }
    public int _baseRes { get { return baseRes; } set { baseRes = value; } }
    public int _res { get { return res; } set { res = value; } }
    public bool _shiny { get { return shiny; } set { shiny = value; } }
    public bool _vegan { get { return vegan; } set { vegan = value; } }
    public int _food { get { return food; } set { food = value; } }
    public int _sun { get { return sun; } set { sun = value; } }
    public int _water { get { return water; } set { water = value; } }
}