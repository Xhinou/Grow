using UnityEngine;

public class Worm : Event
{
    public static bool recentDeath;

    private bool isAlive = false;
    private int deadDays = 0;

    new void Start()
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
        base.OnNewDay();
        if (deadDays > 0)
            deadDays -= 1;
        if (isAlive)
        {
            flower.infested = true;
            deadDays = 5 - (int)flower.age;
            recentDeath = true;
            isAlive = false;
            Destroy(gameObject);
        }
    }
}
