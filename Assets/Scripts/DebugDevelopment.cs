using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugDevelopment : MonoBehaviour
{
    float currentVelocity;
    Vector2 currentVvector;
    public Rigidbody2D characterrb;
    public Text displayText, displayText2;

    void getVelocity()
    {
        currentVelocity = characterrb.velocity.magnitude;
        currentVvector = characterrb.velocity;
    }

    void displayVelocity()
    {
        string tempstr;
        tempstr = currentVelocity.ToString();
        displayText.text = "Current Speed = " + tempstr;
        displayText2.text = "Velocity " + "X- " + currentVvector.x.ToString() + " Y- " + currentVvector.y.ToString(); 
    }

    private void Update()
    {
        getVelocity();
        displayVelocity();
    }
}
