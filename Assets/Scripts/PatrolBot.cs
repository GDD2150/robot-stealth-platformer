using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Simple left right AI patrol that uses a raycast to check if robot is approaching a "cliff"
    a polygon collider will check if the player is in vision
*/
public class PatrolBot : MonoBehaviour
{
    bool isGoingLeft = true;
    RaycastHit2D groundCheck;
    Vector2 bottomLeft;
    Vector2 bottomRight;

    public float groundCheckDistance;
    public LayerMask groundLayer;
    bool hasGround;

    public float patrolSpeed;
    public GameObject light;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer detectionSpriteRenderer;


    void Start()
    {
        bottomLeft = new Vector2(-0.939f, -0.342f); //new Vector2(-1,-1);
        bottomRight = new Vector2(0.939f, -0.342f); //new Vector2(1, -1);

        spriteRenderer = GetComponent<SpriteRenderer>();
        detectionSpriteRenderer = light.GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        // Debug ray (for visualization in Scene view)
        Color rayColor = hasGround ? Color.green : Color.red;
        
        if(isGoingLeft)
        {
            // move left until no more ground
            // use a 45 degree raycast to the ground to check if gap is there or not
            groundCheck = Physics2D.Raycast(transform.position, bottomLeft, groundCheckDistance, groundLayer);
            hasGround = groundCheck.collider != null;
            
            if(groundCheck.collider == null)
            {
                isGoingLeft = false;
                // flip light child obj
                detectionSpriteRenderer.flipX = true;
                spriteRenderer.flipX = true;
                light.transform.localPosition = new Vector2(0.5f, 0.09f);
            }      
            else 
            {
                // move left
                transform.Translate(Vector2.left * patrolSpeed * Time.deltaTime);
            }
            Debug.DrawRay(transform.position, bottomLeft * groundCheckDistance, rayColor);

        }
        else
        {
            // move right until no ground
            groundCheck = Physics2D.Raycast(transform.position, bottomRight, groundCheckDistance, groundLayer);
            hasGround = groundCheck.collider != null;
            if(groundCheck.collider == null)
            {
                isGoingLeft = true;
                // flip light child
                detectionSpriteRenderer.flipX = false;
                spriteRenderer.flipX = false;
                light.transform.localPosition = new Vector2(-0.5f, 0.09f);
            }        
            else 
            {
                // move right
                transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime);
            }
            Debug.DrawRay(transform.position, bottomRight * groundCheckDistance, rayColor);
        }

   
        

    }

    void OnTriggerEnter2d(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            // trigger fail state routine

        }
    }
}
