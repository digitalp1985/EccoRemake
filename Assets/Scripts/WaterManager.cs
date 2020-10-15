using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    public PlayerControlEcco pcontrol;
    public static WaterManager instance;
    void Awake()
    {
        if (instance == null)
        {
            // Set this instance as the instance reference.
            instance = this;
        }
        else if (instance != this)
        {
            // If the instance reference has already been set, and this is not the
            // the instance reference, destroy this game object.
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void leftWater()
    {
        pcontrol.enableGravity();
    }
    
    public void enterWater()
    {
        pcontrol.disableGravity();
    }
}
