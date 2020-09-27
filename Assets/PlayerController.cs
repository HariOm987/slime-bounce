using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask hitspot;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight == true && moveInput <0)
        {
            Flip();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Head"))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        if (col.gameObject.CompareTag("Enemy"))
        {
            BoxCollider2D boxCollider = this.transform.gameObject.GetComponent<BoxCollider2D>();
            Rigidbody2D rigidbody = this.transform.gameObject.GetComponent<Rigidbody2D>();
            SpriteRenderer spriteRenderer = this.transform.gameObject.GetComponent<SpriteRenderer>();
            PlayerController playerController = this.transform.gameObject.GetComponent<PlayerController>();
            spriteRenderer.color = Color.black;
            playerController.enabled = false;
            boxCollider.enabled = false;
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    // Update is called once per frame
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    void Update()
    {

    }
}
