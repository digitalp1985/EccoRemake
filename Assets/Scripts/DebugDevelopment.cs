using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugDevelopment : MonoBehaviour
{
    float currentVelocity;
    Vector2 currentVvector;
    public PlayerControlEcco pcon;
    public Rigidbody2D characterrb;
    public Text displayText, displayText2;
    public Image displaypic;
    bool doneRunning = true;


    void getVelocity()
    {
        currentVelocity = characterrb.velocity.magnitude;
        currentVvector = characterrb.velocity;
    }

    void checkPeak()
    {
        if (doneRunning && characterrb.velocity.y < 0.00001 && pcon.isJumping() )
        {
            StartCoroutine(setGreen());
        }

    }

    IEnumerator setGreen()
    {
        doneRunning = false;
        displaypic.color = Color.green;
        yield return new WaitForSeconds(3);
        displaypic.color = Color.red;
        doneRunning = true;

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
        checkPeak();
    }
}
