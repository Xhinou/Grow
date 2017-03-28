using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : GameManager
{
    enum Age {Young, Adult, Ancient};
    Age age;
    private int rand;

    public int
        food,
        res,
        sun,
        water;
    public bool vegan;

    void Start()
    {
        age = Age.Young;
        DefaultStats(age);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.ClearDeveloperConsole();
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

    void DefaultStats(Age plantAge)
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
            food = rand;
        }
        else
        {
            vegan = true;
            food = 0;
        }
    }

    void Evolve(Age plantAge)
    {
        switch (plantAge) {
            case Age.Young:
                res += 1;
                break;
            case Age.Adult:
                res += 1;
                break;
            case Age.Ancient:
                Debug.Log("Can't grow up anymore !");
                break;
            default:
                Debug.Log("Evolve: Age value error");
                break;
        }
    }

    void RandDice(int dice)
    {
        rand = Random.Range(0, dice) + 1;
        Debug.Log(rand + "/" + dice);
    }
}

public class FlowerStruct : Flower
{
    public int Food { get { return food; } set { food = value; } }
    public int Res { get { return res; } set { res = value; } }
    public int Sun { get { return sun; } set { sun = value; } }
    public int Water { get { return water; } set { water = value; } }
}
