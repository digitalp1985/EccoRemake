using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlEcco : MonoBehaviour
{
    public Rigidbody2D eccobody;
    public EccoSpriteController espritecontrol;
    private float UpDownLeftRight;
    private Vector2 movement, position, facing;
    private float swimSpeed = 4f;
    public float defaultSpeed = 4f;
    public float fastSpeed = 8f;
    public float swimAnimSpeedN = 1f;
    public float swimAnimSpeedF = 2f;
    public float rotateSpeedN = 1f;
    public float rotateSpeedF = 2f;
    private bool moving = false;
    private bool inAir = false;
    private bool rotating;
    Vector2 currentvelocity;
    private float facingLocation, nextLocation, checkLocation, previousLocation;
    [Range(0, .3f)] [SerializeField] private float moveSmooth = .22f;
    private Vector3 velocityreference = Vector3.zero;

    void Start()
    {
        alignFace();
        espritecontrol.initSC();
        swimSpeed = defaultSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        checkSpeed();
        movementInput();
        testGrav();
    }

    void FixedUpdate()
    {
        inputPosition();
        if (rotating)
        {

        }
        else
        { 
        //faceCheck();
        swimNormal();
        }
    }

    void movementInput()
    {
        if (!inAir)
        {
            movement.x = Input.GetAxisRaw("Horizontal") * swimSpeed;
            movement.y = Input.GetAxisRaw("Vertical") * swimSpeed;
        }
    }

    void alignFace()
    {
        facing = movement;
        position = movement;
        facingLocation = 1;
        nextLocation = 1;
        checkLocation = 1;
        rotating = false;
    }

    void checkSpeed()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            swimSpeed = fastSpeed;
            espritecontrol.setFastSpeed(swimAnimSpeedF, rotateSpeedF);
        }
        else
        {
            swimSpeed = defaultSpeed;
            espritecontrol.setNormalSpeed(swimAnimSpeedN, rotateSpeedN);
        }
    }

    public float currentface()
    {
        return facingLocation;
    }

    void swimNormal()
    {
        if (movement == Vector2.zero)
        {
            espritecontrol.goIdle();
        }
        else { espritecontrol.movingAn(); }
        if (!rotating && !inAir)
        {
            Vector3 targetspeed = new Vector2(movement.x, movement.y);
            //eccobody.velocity = Vector3.SmoothDamp(eccobody.velocity, targetspeed, ref velocityreference, moveSmooth);
            eccobody.AddForce(targetspeed);
        }
        }

    
    void inputPosition()
    {
        

        if (movement != Vector2.zero && rotating == false)
        {
            

            if (movement.x / swimSpeed == 1 && movement.y / swimSpeed == 0)
            {
                nextLocation = 1;
            }
            if (movement.x / swimSpeed == 1 && movement.y / swimSpeed == -1)
            {
                nextLocation = 2;
            }
            if (movement.x / swimSpeed == 0 && movement.y / swimSpeed == -1)
            {
                nextLocation = 3;
            }
            if (movement.x / swimSpeed == -1 && movement.y / swimSpeed == -1)
            {
                nextLocation = 4;
            }
            if (movement.x / swimSpeed == -1 && movement.y / swimSpeed == 0)
            {
                nextLocation = 5;
            }
            if (movement.x / swimSpeed == -1 && movement.y / swimSpeed == 1)
            {
                nextLocation = 6;
            }
            if (movement.x / swimSpeed == 0 && movement.y / swimSpeed == 1)
            {
                nextLocation = 7;
            }
            if (movement.x / swimSpeed == 1 && movement.y / swimSpeed == 1)
            {
                nextLocation = 8;
            }
            if (nextLocation != checkLocation)
            {
                Debug.Log("Next Location " + nextLocation);
                rotating = true;
                previousLocation = facingLocation;
                checkLocation = nextLocation;
                espritecontrol.startRotation(facingLocation, nextLocation);
                facingLocation = nextLocation;
            }
            
        }
    }  

    public Vector2 correctRotation()
    {
        Vector2 crot  = new Vector2(previousLocation, facingLocation);

        return crot ;
    }

    public void doneRotating()
    {
        rotating = false;
    }

    void testGrav()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            disableGravity();
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            enableGravity();
        }
    }

    public bool isJumping()
    {
        return inAir;
    }

    public void enableGravity()
    {
        
        currentvelocity = eccobody.velocity;
        eccobody.drag = 0;
        eccobody.angularDrag = 0;
        eccobody.gravityScale = 1;
        inAir = true;
        eccobody.AddForce(checkVelocity(), ForceMode2D.Force);
    }

    public void disableGravity()
    {
        eccobody.drag = 5;
        eccobody.angularDrag = 9;
        eccobody.gravityScale = 0;
        inAir = false;
    }

    Vector2 checkVelocity()
    {
        if (currentvelocity.x < -1.5f)
        {
            return new Vector2(-50, 100);
        }
        if (currentvelocity.x > 1.5f)
        {
            return new Vector2(50, 100);
        }
        else
        {
            return new Vector2(0, 100);
        }
    }
}
