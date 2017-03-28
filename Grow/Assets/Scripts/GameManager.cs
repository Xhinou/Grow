using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int
        day,
        population,
        life;

    void Start()
    {
        day = 1;
        population = 0;
        life = 0;
    }

    void Update()
    {

    }

    public void NextDay()
    {
        day += 1;
    }

    public IEnumerator Timer(GameObject obj, float seconds)
    {
        obj.GetComponent<BoxCollider2D>().enabled = false;
        //Play Disable Animation
        yield return new WaitForSeconds(seconds);
        //Play Enable Animation
        obj.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void CheckPop()
    {
        if (population >= 10)
        {
            life += 1;
            population = 0;
        }
    }

    //Constructors
    public int Population { get { return population; } set { population = value; } }
}
