using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EccoSpriteController : MonoBehaviour
{
    public PlayerControlEcco pcontrol;
    public EccoCollisionController econtrol;
    private Animator animator;
    private float source, destination;
    private bool isRotating;

    void Awake()
    {
        animator = GetComponent<Animator>();
        isRotating = false;
    }

    public void initSC()
    {
        isRotating = false;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        econtrol.initCamera();
        animator.SetFloat("UDLR", 0f);
        animator.SetFloat("RotationSpeed", 1.5f);
        animator.SetFloat("SwimSpeed", 1f);
        econtrol.initializeCollisions();
        animator.SetFloat("CurrentFace", 1f);
    }

    public void setNormalSpeed(float swim, float rotate)
    {
        animator.SetFloat("RotationSpeed", rotate);
        animator.SetFloat("SwimSpeed", swim);
    }

    public void setFastSpeed(float swim, float rotate)
    {
        animator.SetFloat("RotationSpeed", rotate);
        animator.SetFloat("SwimSpeed", swim);
    }
    
    public void faceR()
    {
        animator.SetFloat("UDLR", 0f);
        econtrol.setHCollision();
    }

    public void faceUR()
    {
        
        animator.SetFloat("UDLR", 0f);
        econtrol.setDRCollision();
    }

    public void faceU()
    {   
        animator.SetFloat("UDLR", 1f);
        econtrol.setVCollision();
    }

    public void faceUL()
    {   
        animator.SetFloat("UDLR", 0f);
        econtrol.setDLCollision();
    }

    public void faceL()
    {
        animator.SetFloat("UDLR", 0f);
        econtrol.setHCollision();
    }

    public void faceDL()
    {  
        animator.SetFloat("UDLR", 0f);
        econtrol.setDRCollision();
    }

    public void faceD()
    {
        animator.SetFloat("UDLR", 1f);
        econtrol.setVCollision();
    }

    public void faceDR()
    {
        animator.SetFloat("UDLR", 0f);
        econtrol.setDLCollision();
    }

    public void goIdle()
    {
        animator.SetBool("Moving", false);
    }

    public void movingAn()
    {
        animator.SetBool("Moving", true);
    }
    
    public void startRotation(float input, float input2)
    {
        if (!isRotating)
        {
            isRotating = true;
            animator.SetFloat("CurrentFace", input2);
            animator.SetFloat("StartRotation", input);
            animator.SetFloat("StopRotation", input2);
            animator.SetTrigger("Rotate");
            econtrol.setCameraOrientation(input2);
            source = input;
            destination = input2;
            switch (destination)
            {
                case 1:
                    faceR();
                    break;
                case 2:
                    faceDR();
                    break;
                case 3:
                    faceD();
                    break;
                case 4:
                    faceDL();
                    break;
                case 5:
                    faceL();
                    break;
                case 6:
                    faceUL();
                    break;
                case 7:
                    faceU();
                    break;
                case 8:
                    faceUR();
                    break;

            }
            
        }
    }

    public void startAnimating()
    {
        Debug.Log("Triggered Start Anim");
        
        
        Debug.Log("Triggered Start Anim");
        if (pcontrol.currentface() == destination)
        {
            Debug.Log("Face and Destination match - start");
            
        }
        else
        {
            Debug.Log("Face and destination do not match - start");
            

        }
    }

    

    public void doneAnimating()
    {
        Debug.Log("Triggered Done Anim");
        if (pcontrol.currentface() == destination)
        {
            animator.SetFloat("CurrentFace", destination);
            Debug.Log("Face and Destination match");
            isRotating = false;
            pcontrol.doneRotating();

        }
        else
        {
            Debug.Log("Face and destination do not match");
           

        }
        

        
    }

   
}
