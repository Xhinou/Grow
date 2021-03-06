﻿public class Sun : Event
{
    private int _incGiven;

    private new void Start()
    {
        base.Start();
        incGiven = 0;
    }

    private void OnMouseDown()
    {
        flower.Feed(Flower.Need.Sun, +1);
        Sweat();
        //StartCoroutine(system.Timer(gameObject, 5));
    }

    public override void OnNewDay()
    {
        incGiven = 0;
    }

    private void Sweat()
    {
        incGiven += 1;
        if (incGiven >= 2)
        {
            flower.Feed(Flower.Need.Water, -1);
            incGiven = 0;
        }
    }

    public int incGiven { get { return _incGiven; } set { _incGiven = value; } }
}
