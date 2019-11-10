using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EccoController : MonoBehaviour
{
    Rigidbody2D rbody;
    Animator anim;
    
    public Vector2 facemove;

    // Start is called before the first frame update
    void Start()
    {

        
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetFloat("input_x", 1);
        anim.SetFloat("input_y", 0);

    }

    // Update is called once per frame
    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement_vector = new Vector2(moveHorizontal, moveVertical);
        
        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("moving", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);
            facemove = movement_vector;
        }
        else
        { anim.SetBool("moving", false); }

        rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime * 5);

    }





}
