using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover2 : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveInput;
    public int speed = 5;
    public int jumpForce = 10;
    public bool isGrounded = false;
    // NEW
    public Transform groundCheck; // empty game object child to detect floor
    public float checkRadius;   // radius of the transform object
    public LayerMask whatIsGround;  // which layer is ground

    private int extraJumps;
    public int extraJumpsValue;


    // Use this for initialization
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //NEW

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); //where is it, how big, and what is it looking for?

        // if user presses the space bar then jump

        if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        else if (facingRight == false && moveInput > 0)
        {
            Flip();
        }

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true){
            rb.velocity = Vector2.up * jumpForce;
        }


    }


    void Flip()
    {
        facingRight = !facingRight;
        // Have to create variable to modify localScale x by -1
        Vector3 peach = transform.localScale;
        peach.x *= -1;
        transform.localScale = peach;

    }

    void Jump()
    {
        Debug.Log("jumper");
    }
}
