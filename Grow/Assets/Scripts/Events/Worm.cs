using UnityEngine;

public class Worm : Event
{

    private bool isAlive;

    private new void Start()
    {
        base.Start();
        isAlive = true;
    }

    private void OnMouseDown()
    {
        if (!flower.vegan)
            flower.Feed(Flower.Need.Meat, +1);
        isAlive = false;
        // Kill the worm
        Destroy(gameObject);
    }

    public override void OnNewDay()
    {
        if (isAlive)
        {
            flower.infested = true;
            isAlive = false;
            Destroy(gameObject);
        }
    }
}
