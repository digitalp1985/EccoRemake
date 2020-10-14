using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugDevelopment : MonoBehaviour
{
    float currentVelocity;
    public Rigidbody2D characterrb;
    public Text displayText;

    void getVelocity()
    {
        currentVelocity = characterrb.velocity.magnitude;
    }

    void displayVelocity()
    {
        string tempstr;
        tempstr = currentVelocity.ToString();
        displayText.text = "Current Speed = " + tempstr;
    }

    private void Update()
    {
        getVelocity();
        displayVelocity();
    }
}
