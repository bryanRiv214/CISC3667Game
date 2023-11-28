using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class balloonScript : MonoBehaviour
{
    gameManager gameManager;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] Vector2 position;
    [SerializeField] Vector2 initPosition;
    [SerializeField] public float SPEED;

    [SerializeField] new AudioSource audio;
    [SerializeField] float growInterval = 2f;

    [SerializeField] GameObject controller;

    [SerializeField] Vector2 scale;

    [SerializeField] int level;




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
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
        level = SceneManager.GetActiveScene().buildIndex - 1;

        position = (Vector2)transform.position + Vector2.up;
        InvokeRepeating("GrowObject", 5f, growInterval);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        // adding SPEED to position, updating positon

        position = transform.position;
        position.y += (SPEED * Time.deltaTime);
        transform.position = position;

        if (position.y > initPosition.y + 5 || position.y < initPosition.y - 5)
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
            float delay = GetComponent<AudioSource>().clip.length;
            if (scale.x <= .16)
            {
                System.Console.WriteLine("15");
                controller.GetComponent<Scorekeeper>().AddPoints(10);
            }
            else if (scale.x <= .25)
            {
                controller.GetComponent<Scorekeeper>().AddPoints(5);
            }
            else
            {
                controller.GetComponent<Scorekeeper>().AddPoints(1);
            }
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            Invoke("LoadNextScene", delay);
        }
    }

    void LoadNextScene()
    {
        print("Next Scene Index: " + SceneManager.GetActiveScene().buildIndex + 1);

        // Load next scene 
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void GrowObject()
    {
        // Grow by 10% each time
        float growAmount = 1.1f;

        // Get current scale
        scale = transform.localScale;

        // Scale up on each axis 
        scale.x *= growAmount;
        scale.y *= growAmount;

        // Apply new scale
        transform.localScale = scale;
        if (scale.x > .3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameObject.SetActive(false);
            return;
        }
    }
}
