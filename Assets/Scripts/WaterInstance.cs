using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterInstance : MonoBehaviour
{
    public Collider2D Watercollider;

    private void Start()
    {
        Watercollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            WaterManager.instance.enterWater();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            WaterManager.instance.leftWater();
        }
    }
}
