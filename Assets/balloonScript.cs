using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class balloonScript : MonoBehaviour
{
    gameManager gameManager;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] Vector2 position;
    [SerializeField] Vector2 initPosition;
    [SerializeField] public float SPEED;

    [SerializeField] new AudioSource audio;

    // Start is called before the first frame update

    void Start()
    {
        if (rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
        }
        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }
        position = (Vector2)transform.position + Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {
        // adding SPEED to position, updating positon
        
        position = transform.position;
        position.y += (SPEED * Time.deltaTime);
        transform.position = position;

        if (position.y > initPosition.y+5 || position.y < initPosition.y-5)
        {
            SPEED *= -1;
            Flip();
        }
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "snowball")
        {
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);

            Destroy(gameObject);
            Destroy(collision.gameObject);


        }





    }
}
