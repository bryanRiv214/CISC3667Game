using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class balloonScript : MonoBehaviour
{
    gameManager gameManager;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] Vector2 position;
    [SerializeField] public float SPEED;
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
        // adding SPEED to position, updating positon
        position = transform.position;
        position.x += (SPEED * Time.deltaTime);
        transform.position = position;

        if (position.x > 14 || position.x < -14)
        {
            SPEED *= -1;
            Flip();
        }
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
    }
}
