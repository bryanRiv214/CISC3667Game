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
        yMovement = Input.GetAxis("Vertical");
        /*if(Input.GetButtonDown("Jump")){
            jumpPressed = true;
        }*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    // potentially called many times per frame, best for physics
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(xMovement * SPEED, yMovement * SPEED);
        if (xMovement < 0 && isFacingRight || xMovement > 0 && !isFacingRight)
        {
            Flip();
        }

    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        movement*=-1;
        isFacingRight = !isFacingRight;
    }

    void Shoot()
    {
        GameObject snowballObject = Instantiate(snowball, transform.position, Quaternion.identity);
        snowballObject.GetComponent<Rigidbody2D>().velocity = new Vector2(movement, 0f);
    }

}
