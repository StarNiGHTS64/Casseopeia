using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateEnemy : MonoBehaviour
{

    [SerializeField]
    float rayDistance = 12f;

    [SerializeField]
    GameObject player;

    RaycastHit2D raycast;
    Pathfinding.AILerp aiLerp;

    bool playerSpotted = false;

    Rigidbody2D rb;
    float prevX;
    float currentX;
    float prevY;
    float currentY;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        aiLerp = GetComponent<Pathfinding.AILerp>();
        aiLerp.canMove = false;
        currentX = prevX = rb.transform.position.x;
        currentY = prevY = rb.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (aiLerp.canMove)
        {
            currentX = rb.transform.position.x;
            currentY = rb.transform.position.y;

            anim.SetFloat("Horizontal", currentX - prevX);
            anim.SetFloat("Vertical", currentY - prevY);
            anim.SetBool("isMoving", true);

            if (currentX - prevX == 0)
            {
                anim.SetFloat("Horizontal", 0);
            }
            if (currentY - prevY == 0)
            {
                anim.SetFloat("Vertical", 0);
            }
            prevX = currentX;
            prevY = currentY;
        }
        else
        {
            anim.SetFloat("Horizontal", 0);
            anim.SetFloat("Vertical", 0);
            anim.SetFloat("Speed", 0);
            anim.SetBool("isMoving", false);
        }
    }

    void FixedUpdate()
    {
        if (!playerSpotted)
        {
            SearchForPlayer();
        }
        if (!PlayerInRange())
        {
            aiLerp.canMove = false;
            playerSpotted = false;
        }
    }

    void SearchForPlayer()
    {
        var rayOrigin = new Vector2(transform.position.x, transform.position.y);
        var rayDestination = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);

        //cast a ray and ignore all layers except for player layer
        raycast = Physics2D.Raycast(rayOrigin, rayDestination, rayDistance, 1 << LayerMask.NameToLayer("Player"));

        if (raycast.collider != null)
        {
            aiLerp.canMove = true;
            playerSpotted = true;
        }
        Debug.DrawRay(rayOrigin, rayDestination.normalized * rayDistance, Color.green);
    }

    bool PlayerInRange()
    {
        var inRange = false;
        var distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance > rayDistance)
        {
            inRange = false;
        }
        else
        {
            inRange = true;
        }
        return inRange;
    }
}
