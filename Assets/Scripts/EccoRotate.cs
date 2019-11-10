using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EccoRotate : MonoBehaviour
{
    
   
    
   
    public GameObject DiagR;
    public GameObject DiagL;
    public GameObject Vert;
    public GameObject Horiz;

    #region Singleton

    public static EccoRotate instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    void Start()
    {
        setRotationRL();
        
    }

    

    public void setRotationDiagonalR()
    {
        DiagL.SetActive(false);
        DiagR.SetActive(true);
        Vert.SetActive(false);
        Horiz.SetActive(false);
    }

    public void setRotationDiagonalL()
    {
        DiagL.SetActive(true);
        DiagR.SetActive(false);
        Vert.SetActive(false);
        Horiz.SetActive(false);

    }

    public void setRotationRL()
    {
        DiagL.SetActive(false);
        DiagR.SetActive(false);
        Vert.SetActive(false);
        Horiz.SetActive(true);


    }

    public void setRotationUD()
    {
        DiagL.SetActive(false);
        DiagR.SetActive(false);
        Vert.SetActive(true);
        Horiz.SetActive(false);
    }

}
