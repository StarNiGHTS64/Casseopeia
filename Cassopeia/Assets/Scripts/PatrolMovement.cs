using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    [SerializeField]
    GameObject patrol;
    Animator patrolAnimator;

    [SerializeField]
    Transform castPoint;

    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    bool isFacingLeft;

    private bool isAgro = false;
    private bool isSearching;

    HPHandler HPHandler;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        patrolAnimator = patrol.GetComponent<Animator>();
        HPHandler = GameObject.Find("HPHandler").GetComponent<HPHandler>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CanSeePlayer(agroRange))
        {
            isAgro = true;
        }
        else
        {
            if(isAgro)
            {
                
                if(!isSearching)
                {
                    isSearching = true;
                    Invoke("StopChasingPlayer", 3);
                }
                
            }
            
        }
        if(isAgro)
        {
            ChasePlayer();
        }
    }

    bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = distance;

        if(isFacingLeft)
        {
            castDist = -distance;
        }


        Vector2 endPos = castPoint.position + Vector3.right * castDist;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if(hit.collider != null)
        {
            if(hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;
                HPHandler.alert = 3;
                Debug.Log("TRUE");
            }
            else
            {
                val = false;
                Debug.Log("FALSE");
            }
            Debug.DrawLine(castPoint.position, hit.point, Color.red);
        }
        else
        {
            Debug.DrawLine(castPoint.position, endPos, Color.blue);
        }

        return val;
    }

    void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
            isFacingLeft = false;
            Debug.Log("Right");
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
            isFacingLeft = true;
            Debug.Log("Left");
        }
        Debug.Log("I SEE IT");
        //patrolAnimator.Play("Idle");
    }

    void StopChasingPlayer()
    {
        isAgro = false;
        isSearching = false;
        rb2d.velocity = new Vector2(0, 0);
        //patrolAnimator.Play("Run");
    }
}
