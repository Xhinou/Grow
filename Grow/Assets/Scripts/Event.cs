using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    protected GameManager system;
    protected Flower flower;

    private float delay;

    //public GameManager System { get; set; }
    //protected Flower Flower { get; set; }

    protected void Start()
    {
        system = gameObject.GetComponent<GameManager>();
        flower = GameObject.Find("Flower").GetComponent<Flower>();
    }

    protected void OnMouseEnter()
    {
        Debug.Log("Interaction : " + gameObject.name);
    }
}
