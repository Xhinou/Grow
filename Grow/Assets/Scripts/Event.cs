using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : GameManager
{
    public Event[] myEvents;
    public GameObject[] eventsObjects;

    protected Controller controller;
    protected Flower flower;

    private void Awake()
    {
            myEvents = eventsObjects.FindObjectsOfType<Event>();
    }

    protected void Start()
    {
        controller = GameObject.Find("System").GetComponent<Controller>();
        flower = GameObject.Find("Flower").GetComponent<Flower>();
    }

    protected void OnMouseEnter()
    {
    }

    public virtual void OnNewDay()
    {
        print(gameObject.name);
    }

    private void PopWorm()
    {
        if (randDice(16) == 16 - ((int)flower.age * 2))
        {
            // Create a worm
            Worm worm = FindObjectOfType<Worm>();
            Instantiate(worm);
        }
    }

    private void UpdateEvents()
    {
        Awake();
    }
}
