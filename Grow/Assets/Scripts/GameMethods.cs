using UnityEngine;

namespace GlobalMethods
{
    public class GameMethods
    {
        public static int randDice(int dice)
        {
            int rand = Random.Range(0, dice) + 1;
            if (rand > dice)
                rand = dice;
            Debug.Log(rand + "/" + dice);
            return rand;
        }
    }
}
