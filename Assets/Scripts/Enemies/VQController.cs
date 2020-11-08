using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using UnityEngine;

public class VQController : MonoBehaviour
{
    public Rigidbody2D vqrb, detectedPlayer;
    public CircleCollider2D awareness;
    public GameObject leftEye, rightEye;
    public Vector2 lEye = new Vector2(-2f, -1.8f);
    public Vector2 rEye = new Vector2(1.8f, 2f);
    public Vector2 eyeY = new Vector2(-1.18f, -1.5f);
    public Vector3 defR, defL;
    public bool isNearby = false;
    IEnumerator moving;
    public float detectDistance = 10f;

    private void Awake()
    {
        awareness.radius = detectDistance;
        defR = rightEye.transform.localPosition;
        defL = leftEye.transform.localPosition;
    }

    private void Update()
    {
        checkEnemy();
    }

    void checkEnemy()
    {
        if (isNearby)
        {
            if (moving == null)
            {
                moving = moveTowards();
                StartCoroutine(moving);
            }
            

        }
        else 
        {
            if (moving != null)
            {
                StopCoroutine(moving);
                StopCoroutine(lookTowards());
                moving = null;
            }

        }
    }

    IEnumerator lookTowards()
    {
        while(isNearby)
        {
            yield return new WaitForSeconds(.1f);
            lookatPlayer();
        }
    }

    IEnumerator moveTowards()
    {
        StartCoroutine(lookTowards());
        while (isNearby)
        {
            vqrb.MovePosition(Vector2.Lerp(transform.position, detectedPlayer.transform.position, .01f));
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Detected player");
            isNearby = true;
            detectedPlayer = collision.gameObject.GetComponentInParent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && DetectDistance(collision) > detectDistance)
        {
            Debug.Log("Player evaded " + DetectDistance(collision));
            isNearby = false;
            detectedPlayer = null;
        }
    }

    float DetectDistance(Collider2D collision)
    {
        return Vector3.Distance(collision.transform.position, transform.position);
    }

    void lookatPlayer()
    {
        if (detectedPlayer != null)
        {
            Vector3 rposition = relativePosition() * 10;
            leftEye.transform.localPosition = new Vector3(Mathf.Clamp((rposition.x + leftEye.transform.localPosition.x), lEye.x, lEye.y), Mathf.Clamp((rposition.y + leftEye.transform.localPosition.y), eyeY.x, eyeY.y), 0);
            rightEye.transform.localPosition = new Vector3(Mathf.Clamp((rposition.x + rightEye.transform.localPosition.x), rEye.x, rEye.y), Mathf.Clamp((rposition.y + leftEye.transform.localPosition.y), eyeY.x, eyeY.y), 0);
        }
    }

    Vector2 relativePosition()
    {
        
        Vector2 relativePosition = new Vector2(detectedPlayer.transform.position.x - transform.position.x, 1f + transform.position.y - detectedPlayer.transform.position.y);
        return relativePosition.normalized;
        
        

    }
}
