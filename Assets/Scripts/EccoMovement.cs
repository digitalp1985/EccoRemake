using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EccoMovement : MonoBehaviour
{
    public float speed;
   
    
    private bool moving, idle, rotating, updated;
    private Vector2 direction;
    private int rotate;
    private int currentFace, nextFace, moveFace;
    EccoAnimation eccoanim;
    Transform Ptransform;


    // Start is called before the first frame update
    void Start()
    {
       
        eccoanim = GetComponentInChildren<EccoAnimation>();
        currentFace = 3;
        nextFace = 3;
        moveFace = 3;
        rotating = false;
        moving = false;
        Ptransform = GetComponent<Transform>();
        GetComponent<Rigidbody2D>().gravityScale = 0f;
    }

    
    void FixedUpdate()
    {
        eccoanim = GetComponentInChildren<EccoAnimation>();
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        

        if (moveVertical > 0 && moveHorizontal == 0 && moving == false )
        {
            idle = false;
            moveFace = 1;
            moving = true;
        }
        if (moveVertical > 0 && moveHorizontal > 0 && moving == false )
        {
            idle = false;
            moveFace = 2;
            moving = true;
        }
        if (moveVertical == 0 && moveHorizontal > 0 && moving == false )
        {
            idle = false;
            moveFace = 3;
            moving = true;
        }
        if (moveVertical < 0 && moveHorizontal > 0 && moving == false )
        {
            idle = false;
            moveFace = 4;
            moving = true;
        }
        if (moveVertical < 0 && moveHorizontal == 0 && moving == false )
        {
            idle = false;
            moveFace = 5;
            moving = true;
        }
        if (moveVertical < 0 && moveHorizontal < 0 && moving == false )
        {
            idle = false;
            moveFace = 6;
            moving = true;
        }
        if (moveVertical == 0 && moveHorizontal < 0 && moving == false )
        {
            idle = false;
            moveFace = 7;
            moving = true;
        }
        if (moveVertical > 0 && moveHorizontal < 0 && moving == false )
        {
            idle = false;
            moveFace = 8;
            moving = true;
        }
        

        

        isRotating();
        moveRotate();
        eccoanim.isMoving(moving);
        eccoanim.isIdle(idle);
        isRotating();
        eccoanim.isRotating(rotating);
        
        
        

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            direction = movement;

        if (rotating)
        {
            Debug.Log("Next face is " + nextFace);
            Debug.Log("Current face is " + currentFace);
            //Debug.Log("Rotate is " + rotate);
            Debug.Log("Move face is " + moveFace);
        }

        if (rotating == false && !idle )
        {
            updateWhileIdle();
            GetComponent<Rigidbody2D>().velocity = movement * speed;
            GetComponent<Rigidbody2D>().position = new Vector2
            (
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, -100, 100), Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, -100, 100)
            );
            
            
        }
        if (moveVertical == 0 && moveHorizontal == 0 && moving == false)
        {
            idle = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            updated = false;


        }
        moving = false;

    }

    void updateWhileIdle()
    {
        if (!idle)
        {
            Ptransform.position = eccoanim.Etransform.position;
            
            
        }
    }

    public void moveRotate()
    {
        

        if (rotating && eccoanim.isAnimating())
        {
            //if (moveFace == 3 && currentFace == 7 || moveFace == 7 && currentFace == 3)
            //{
                //Horizontal flip
            //}
            //if (moveFace == 1 && currentFace == 5 || moveFace == 5 && currentFace == 1)
            //{
                //Vertical flip
            //}
            if (moveFace > currentFace)
            {
                if (moveFace - currentFace > 4)
                {
                    rotate = -1;

                }
                else
                    rotate = 1;
            }

            if (moveFace < currentFace)
                {
                    if (currentFace - moveFace > 4)
                    {
                        rotate = 1;

                    }
                    else
                        rotate = -1;

                }
            nextFace = currentFace + rotate;
            if (nextFace == 9)
                nextFace = 1;
            if (nextFace == 0)
                nextFace = 8;
            if(rotate == -1)
            {
                switch (nextFace)
                {
                    case 1:
                        eccoanim.setTurnDirection(1);
                        eccoanim.initiateTurnDirection();
                        Debug.Log("CLW 1");
                        rotating = false;
                        currentFace = nextFace;
                        break;
                    case 2:
                        eccoanim.setTurnDirection(3);
                        eccoanim.initiateTurnDirection();
                        Debug.Log("CLW 2");
                        rotating = false;
                        currentFace = nextFace;
                        break;
                    case 3:
                        eccoanim.setTurnDirection(5);
                        eccoanim.initiateTurnDirection();
                        Debug.Log("CLW 3");
                        rotating = false;
                        currentFace = nextFace;
                        break;
                    case 4:
                        eccoanim.setTurnDirection(7);
                        eccoanim.initiateTurnDirection();
                        Debug.Log("CLW 4");
                        rotating = false;
                        currentFace = nextFace;
                        break;
                    case 5:
                        eccoanim.setTurnDirection(9);
                        eccoanim.initiateTurnDirection();
                        Debug.Log("CLW 5");
                        rotating = false;
                        currentFace = nextFace;
                        break;
                    case 6:
                        eccoanim.setTurnDirection(11);
                        eccoanim.initiateTurnDirection();
                        Debug.Log("CLW 6");
                        rotating = false;
                        currentFace = nextFace;
                        break;
                    case 7:
                        eccoanim.setTurnDirection(13);
                        eccoanim.initiateTurnDirection();
                        Debug.Log("CLW 7");
                        rotating = false;
                        currentFace = nextFace;
                        break;
                    case 8:
                        eccoanim.setTurnDirection(15);
                        eccoanim.initiateTurnDirection();
                        Debug.Log("CLW 8");
                        rotating = false;
                        currentFace = nextFace;
                        break;
                }
            }
            if(rotate == 1)
            {
                switch (nextFace)
                {
                    case 1:
                        eccoanim.setTurnDirection(16);
                        eccoanim.initiateTurnDirection();
                        Debug.Log("CCW 1");
                        
                        currentFace = nextFace;
                        break;
                    case 2:
                        eccoanim.setTurnDirection(2);
                        eccoanim.initiateTurnDirection();
                        Debug.Log("CCW 2");

                        currentFace = nextFace;
                        break;
                    case 3:
                        eccoanim.setTurnDirection(4);
                        eccoanim.initiateTurnDirection();
                        Debug.Log("CCW 3");
                        
                        currentFace = nextFace;
                        break;
                    case 4:
                        eccoanim.setTurnDirection(6);
                        eccoanim.initiateTurnDirection();
                        Debug.Log("CCW 4");
                        
                        currentFace = nextFace;
                        break;
                    case 5:
                        eccoanim.setTurnDirection(8);
                        eccoanim.initiateTurnDirection();
                        Debug.Log("CCW 5");
                        
                        currentFace = nextFace;
                        break;
                    case 6:
                        eccoanim.setTurnDirection(10);
                        eccoanim.initiateTurnDirection();
                        Debug.Log("CCW 6");
                        
                        currentFace = nextFace;
                        break;
                    case 7:
                        eccoanim.setTurnDirection(12);
                        eccoanim.initiateTurnDirection();
                        Debug.Log("CCW 7");

                        currentFace = nextFace;
                        break;
                    case 8:
                        eccoanim.setTurnDirection(14);
                        eccoanim.initiateTurnDirection();
                        Debug.Log("CCW 8");

                        currentFace = nextFace;
                        break;

                }
            }
            rotate = 0;

        }



       // if (moveFace < 5 && moveFace > 1)
         //   transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        //else if (moveFace < 9 && moveFace > 5 )
          //  transform.localRotation = Quaternion.Euler(180f, 0f, 180f);
    }

    public bool isRotating()
    {
        if (moveFace == nextFace && moveFace == currentFace)
        {
            rotating = false;
            return false;
        }
        else
        {
            rotating = true;
            
            return true;
        }

    }

    public void setCurrentface(int cfint)
    {
        currentFace = cfint;
    }
}
