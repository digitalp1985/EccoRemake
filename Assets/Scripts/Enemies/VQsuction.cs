using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class VQsuction : MonoBehaviour
{
    public CircleCollider2D suctionArea;
    public Rigidbody2D target;
    public bool closeBy, MouthOpen;
    public Animator jawAnim;
    IEnumerator csuction;
    public float tbeamdistance = 4f;

    private void Awake()
    {
        suctionArea.radius = tbeamdistance;
    }

    private void Update()
    {
        checkClose();
    }

    void checkClose()
    {
        if (closeBy)
        {
            jawAnim.SetBool("TargetNear", true);

        }
        else { jawAnim.SetBool("TargetNear", false); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            closeBy = true;
            target = collision.gameObject.GetComponentInParent<Rigidbody2D>();
            startSuction();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && localDistance(collision) > tbeamdistance)
        {
            closeBy = false;
            target = null;
            if (csuction != null)
            { 
                StopCoroutine(csuction);
                csuction = null;
            }
        }
    }

    public void startSuction()
    {
        if (csuction == null)
        {
            csuction = tractorBeam();
            StartCoroutine(csuction);
        }
    }

    IEnumerator tractorBeam()
    {
        while (closeBy)
        {
            
            yield return new WaitForSeconds(.1f);
            if (target != null)
            {
                target.AddForce(relativePosition() * 100);
            }
        
        }
        
    }

    float localDistance(Collider2D input)
    {
        return Vector3.Distance(input.transform.position, transform.position);
    }

    Vector2 relativePosition()
    {
        Vector2 relativePosition = new Vector2(transform.position.x - target.transform.position.x, transform.position.y - target.transform.position.y);
        return relativePosition.normalized;
    }
}
