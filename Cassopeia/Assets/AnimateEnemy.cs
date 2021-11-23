using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateEnemy : MonoBehaviour
{

    [SerializeField]
    float rayDistance = 5f;

    [SerializeField]
    GameObject player;

    RaycastHit2D raycast;

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
        currentX = prevX = rb.transform.position.x;
        currentY = prevY = rb.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        currentX = rb.transform.position.x;
        currentY = rb.transform.position.y;

        anim.SetFloat("Horizontal", currentX - prevX);
        anim.SetFloat("Vertical", currentY - prevY);
        
        if(currentX - prevX == 0)
        {
            anim.SetFloat("Horizontal", 0);
        }
        if(currentY - prevY == 0)
        {
            anim.SetFloat("Vertical", 0);
        }
        prevX = currentX;
        prevY = currentY;
    }

    void FixedUpdate()
    {
        raycast = Physics2D.Raycast(transform.position, player.transform.position, rayDistance);
        if(raycast.collider != null)
        {
            Debug.Log("In range");
        }
        else
        {
            Debug.Log("Outside range");
        }

        Debug.DrawRay(transform.position, player.transform.position * rayDistance, Color.green);
    }
}
