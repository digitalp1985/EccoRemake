using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EccoController : MonoBehaviour
{
   

    #region Singleton

    public static EccoController instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    
    
}
