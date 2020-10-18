using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EccoMovement_rev : MonoBehaviour
{
    public float speed;


    private bool moving, idle, rotating, updated, flipping;
    private Vector2 direction;
    private int rotate;
    private int currentFace, nextFace, moveFace;
    private Animator m_Animator;
    private Vector2 m_Facing = Vector2.right;

    Transform Ptransform;

    private void Awake()
    {
        m_Animator = gameObject.GetComponentInChildren<Animator>();
        m_Animator.SetFloat("Dir_x", m_Facing.x);
        m_Animator.SetFloat("Dir_y", m_Facing.y);

        
    }

    // Start is called before the first frame update
    void Start()
    {

        
        currentFace = 3;
        nextFace = 3;
        moveFace = 3;
        rotating = false;
        moving = false;
        flipping = false;
        Ptransform = GetComponent<Transform>();
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        
    }

    private void LateUpdate()
    {
        m_Animator.SetFloat("Face_x", m_Facing.x);
        m_Animator.SetFloat("Face_y", m_Facing.y);
    }

    void FixedUpdate()
    {
        Vector2 moveV = Vector2.zero;
        moveV.x = Input.GetAxisRaw("Horizontal");
        moveV.y = Input.GetAxisRaw("Vertical");
        
        m_Facing = moveV;



        if (moveV.y > 0 && moveV.x == 0 && moving == false)
        {
            idle = false;
            moveFace = 1;
            moving = true;
        }
        if (moveV.y > 0 && moveV.x > 0 && moving == false)
        {
            idle = false;
            moveFace = 2;
            moving = true;
        }
        if (moveV.y == 0 && moveV.x > 0 && moving == false)
        {
            idle = false;
            moveFace = 3;
            moving = true;
        }
        if (moveV.y < 0 && moveV.x > 0 && moving == false)
        {
            idle = false;
            moveFace = 4;
            moving = true;
        }
        if (moveV.y < 0 && moveV.x == 0 && moving == false)
        {
            idle = false;
            moveFace = 5;
            moving = true;
        }
        if (moveV.y < 0 && moveV.x < 0 && moving == false)
        {
            idle = false;
            moveFace = 6;
            moving = true;
        }
        if (moveV.y == 0 && moveV.x < 0 && moving == false)
        {
            idle = false;
            moveFace = 7;
            moving = true;
        }
        if (moveV.y > 0 && moveV.x < 0 && moving == false)
        {
            idle = false;
            moveFace = 8;
            moving = true;
        }

        
        

        



        Vector2 movement = new Vector2(moveV.x, moveV.y);
        direction = movement;

        


        if (rotating == false && !idle)
        {

            
            GetComponent<Rigidbody2D>().velocity = movement * speed;
            GetComponent<Rigidbody2D>().position = new Vector2
            (
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, -100, 100), Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, -100, 100)
            );
            updated = false;

        }
        if (moveV.y == 0 && moveV.x == 0 && moving == false)
        {
            idle = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            updated = false;

            currentFace = nextFace;
            moveFace = currentFace;

        }
        moving = false;

    }




}


    
