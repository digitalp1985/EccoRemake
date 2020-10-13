using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EccoCollisionController : MonoBehaviour
{
    public GameObject[] collisions;
    public Vector3[] orientations;
    public GameObject cameraFocus;

    public void initializeCollisions()
    {
        turnoffCollision();
        turnonCollision(0);
    }

    public void initCamera()
    {
        cameraFocus.transform.localPosition = orientations[0];
    }

    public void setCameraOrientation(float input)
    {
        int intInput = (int)input;
        cameraFocus.transform.localPosition = orientations[intInput];
    }

    void turnoffCollision()
    {
        for (int i = 0; i < collisions.Length; i++)
        {
            collisions[i].SetActive(false);
        }
    }

    void turnonCollision(float input)
    {
        int check = (int) input;
        if (check < collisions.Length)
        {
            collisions[check].SetActive(true);
        }
    }

    public void setHCollision()
    {
        turnoffCollision();
        turnonCollision(0);
    }

    public void setVCollision()
    {
        turnoffCollision();
        turnonCollision(1);
    }

    public void setDRCollision()
    {
        turnoffCollision();
        turnonCollision(2);
    }

    public void setDLCollision()
    {
        turnoffCollision();
        turnonCollision(3);
    }
}
