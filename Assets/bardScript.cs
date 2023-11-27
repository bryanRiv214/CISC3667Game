using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float xMovement;
    [SerializeField] float yMovement;
    [SerializeField] public const int SPEED = 15;
    [SerializeField] bool isFacingRight = true;

    [SerializeField] const float JUMPFORCE = 500.0f;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] bool isGrounded = false;

    public GameObject snowball;

    public float movement = 10f;


    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        xMovement = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumpPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    // potentially called many times per frame, best for physics
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(xMovement * SPEED, rigid.velocity.y);
        if (xMovement < 0 && isFacingRight || xMovement > 0 && !isFacingRight)
        {
            Flip();
        }
        if (jumpPressed && isGrounded)
            Jump();
        else
        {
            if (isGrounded)
            {
                // if (movement > 0 || movement < 0)
                //     animator.SetInteger("motion", RUN);
                // else if (movement == 0)
                //     animator.SetInteger("motion", IDLE);
            }
        }
    }
    void Jump()
    {
        //animator.SetInteger("motion", JUMP);
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, JUMPFORCE));
        jumpPressed = false;
        isGrounded = false;
    }
    void Flip()
    {
        transform.Rotate(0, 180, 0);
        movement *= -1;
        isFacingRight = !isFacingRight;
    }

    void Shoot()
    {
        GameObject snowballObject = Instantiate(snowball, transform.position, Quaternion.identity);
        snowballObject.GetComponent<Rigidbody2D>().velocity = new Vector2(movement, 0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jumpPressed = false;
            //animator.SetInteger("motion", IDLE);
        }
    }

}
