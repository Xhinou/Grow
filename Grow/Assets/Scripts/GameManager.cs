using UnityEngine;

public class GameManager : MonoBehaviour
{
    protected EventsLoader events;

    private void Start()
    {
        events = gameObject.GetComponent<EventsLoader>();
    }

    protected int randDice(int dice)
    {
        int rand = Random.Range(0, dice) + 1;
        if (rand > dice)
            rand = dice;
        Debug.Log(rand + "/" + dice);
        return rand;
    }
}