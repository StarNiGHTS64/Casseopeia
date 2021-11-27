using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    public ParticleSystem dust;

    float prevHorizontal;

    Vector2 movement;

    private void Start()
    {
        prevHorizontal = Input.GetAxisRaw("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(prevHorizontal != movement.x)
        {
            prevHorizontal = Input.GetAxisRaw("Horizontal");
            CreateDust();

        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void CreateDust()
    {
        dust.Play();
    }
}

