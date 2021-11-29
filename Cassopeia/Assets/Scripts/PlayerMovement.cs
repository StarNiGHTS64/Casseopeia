using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        transform.position.Set(PlayerData.position.x, PlayerData.position.y, 0);
        prevHorizontal = Input.GetAxisRaw("Horizontal");
        PlayerData.keyCount = 0;
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

