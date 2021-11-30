using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimateEnemy : MonoBehaviour
{

    [SerializeField]
    float rayDistance = 12f;

    [SerializeField]
    GameObject player;

    RaycastHit2D raycast;
    Pathfinding.AILerp aiLerp;

    HPHandler HPHandler;

    bool playerSpotted = false;

    Rigidbody2D rb;
    float prevX;
    float currentX;
    float prevY;
    float currentY;
    Animator anim;

    // music handles
    public AudioClip NormalClip;
    public AudioClip ChaseClip;
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        aiLerp = GetComponent<Pathfinding.AILerp>();
        aiLerp.canMove = false;
        currentX = prevX = rb.transform.position.x;
        currentY = prevY = rb.transform.position.y;
        HPHandler = GameObject.Find("HPHandler").GetComponent<HPHandler>();
        audioManager = FindObjectOfType<AudioManager>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
        if (collision.transform.tag == "Player")
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }

    void SearchForPlayer()
    {
        var rayOrigin = new Vector2(transform.position.x, transform.position.y);
        var rayDestination = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);

        //cast a ray and ignore all layers except for player layer
        raycast = Physics2D.Raycast(rayOrigin, rayDestination, rayDistance, 1 << LayerMask.NameToLayer("Player"));

        // found player
        if (raycast.collider != null)
        {
            HPHandler.alert = 3;
            aiLerp.canMove = true;
            playerSpotted = true;
            audioManager.ChangeBGM(ChaseClip);
        }
        Debug.DrawRay(rayOrigin, rayDestination.normalized * rayDistance, Color.green);
    }

    bool PlayerInRange()
    {
        var inRange = false;
        var distance = Vector2.Distance(transform.position, player.transform.position);
        // has lost view of player
        if(distance > rayDistance)
        {
            inRange = false;
            HPHandler.alert = 0;
            audioManager.ChangeBGM(NormalClip);
        }
        else
        {
            inRange = true;
        }
        return inRange;
    }

    
}
