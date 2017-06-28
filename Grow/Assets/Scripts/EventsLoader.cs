using UnityEngine;

public class EventsLoader : Grow
{
    public GameObject
        sun,
        cloud,
        bee,
        worm;

    public void LoadEvent(GameObject prefab)
    {
        Event prefabScript = prefab.GetComponent<Event>();
        Instantiate(prefab, prefabScript.spawn, Quaternion.identity);
    }
}

