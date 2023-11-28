using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gnarScript : MonoBehaviour
{
    [SerializeField] Vector2 position;
    [SerializeField] Vector2 initPosition;

    public float speed = 5f;
    [SerializeField] Rigidbody2D rigid;



    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        // Make kinematic
        rigid.isKinematic = true;
        position = (Vector2)transform.position + Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        position = transform.position;
        position.x -= (speed * Time.deltaTime);
        transform.position = position;

         if (position.x > initPosition.x-3 || position.x < initPosition.x - 10)
        {
            speed *= -1;
            Flip();
        }
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
    }
}
