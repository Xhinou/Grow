using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    //States
    enum Age {Young, Adult, Ancient};
    [SerializeField] private Age age;

    public enum Need { Food, Sun, Water};
    //public Need needs;

    //Stats
    [SerializeField] private int
        baseFood,
        baseSun,
        baseWater,
        res;
    [SerializeField] private bool vegan;

    //Givens
    private int
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
    
    void OnMouseDown()
    {
        /*
        Play Animation,
        Show needs
        */
    }

    //Setting default stats
    private void DefaultStats(Age flowerAge)
    {
        res = 5;
        RandDice(5);
        sun = rand;
        RandDice(5);
        water = rand;
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

    //When the flower is growing up
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

    private void RandDice(int dice)
    {
        rand = Random.Range(0, dice) + 1;
        Debug.Log(rand + "/" + dice);
    }

    private void ModRes(int mod)
    {
        res += mod;
    }

    //Constructors
    public int Food { get { return food; } set { food = value; } }
    public int Res { get { return res; } set { res = value; } }
    public int Sun { get { return sun; } set { sun = value; } }
    public int Water { get { return water; } set { water = value; } }
    public bool Vegan { get { return vegan; } set { vegan = value; } }
}