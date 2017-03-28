using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
   // protected GameManager system;
    private Flower flower;

    //public GameManager System { get; set; }
    protected Flower Flower { get; set; }

    private void Start()
    {
        //system = GameObject.Find("System").GetComponent<GameManager>();
    }

    protected void OnMouseEnter()
    {
        Debug.Log("Interaction : " + gameObject.name);
    }
}
