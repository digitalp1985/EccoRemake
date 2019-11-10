using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EccoAnimation : MonoBehaviour
{
    private bool anmoving, anidle, andone, anrotating;
    private int turnDirection = 0;
    private int faceDir;
    private Animator animator;
    private Vector2 animdirection;
    public Transform Etransform;
    EccoMovement eccoMovement;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Etransform = GetComponent<Transform>();
        andone = true;
    }

    // Update is called once per frame
    void Update()
    {


        animator.SetBool("NoInput", anidle);
        animator.SetBool("SwimmingNormal", anmoving);
        animator.SetBool("RotationDone", anrotating);

    }

    public void isMoving(bool move)
    {
        anmoving = move;

    }

    public void isIdle(bool stopped)
    {
        anidle = stopped;


    }



    public void setTurnDirection(int direction)
    {
        turnDirection = direction;
    }
    public void initiateTurnDirection()
    {
        animator.SetInteger("TurnInt", turnDirection);
    }
    public void clearTurnDirection()
    {
        animator.SetInteger("TurnInt", 0);
    }


    public void doneAnimating()
    {
        andone = true;
        clearTurnDirection();
    }

    public void startAnimating()
    {
        andone = false;
    }

    public bool isAnimating()
    {
        return andone;
    }

    public void setNeutral()
    {
        Etransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void faceDiagUR()
    {
        Etransform.localRotation = Quaternion.Euler(0f, 0f, 45f);
        EccoRotate.instance.setRotationDiagonalL();
        faceDir = 2;

    }
    public void faceDiagUL()
    {
        Etransform.localRotation = Quaternion.Euler(0f, 180f, 45f);
        EccoRotate.instance.setRotationDiagonalR();
        faceDir = 8;
    }
    public void faceDiagDL()
    {
        Etransform.localRotation = Quaternion.Euler(0f, 180f, -45f);
        EccoRotate.instance.setRotationDiagonalL();
        faceDir = 6;
    }
    public void faceDiagDR()
    {
        Etransform.localRotation = Quaternion.Euler(0f, 0f, -45f);
        EccoRotate.instance.setRotationDiagonalR();
        faceDir = 4;
        
    }
    
    public void faceRL()
    {
        Etransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        EccoRotate.instance.setRotationRL();
        faceDir = 3;
        
    }

    public void flipRL()
    {
        Etransform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        faceDir = 7;
    }

    public void faceD()
    {
        Etransform.localRotation = Quaternion.Euler(180f, 0f, 0f);
        EccoRotate.instance.setRotationUD();
        faceDir = 5;
    }
    public void faceU()
    {
        Etransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        faceDir = 1;
    }

    public void isRotating(bool rot)
    {
        anrotating = rot;
    }

    public int faceDirection()
    {
        return faceDir;
    }
}
