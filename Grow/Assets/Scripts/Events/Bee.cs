﻿public class Bee : Event
{
    private new void Start()
    {
        base.Start();
    }

    private void OnMouseDown()
    {
        gameManager.Populate();
        //Play Bee Animation
        //Destroy(gameObject);
        print("Bee destroyed");
    }

    public override void OnNewDay()
    {

    }
}
