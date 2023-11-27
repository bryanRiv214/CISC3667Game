using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwSnowball : MonoBehaviour
{
    public GameObject snowball;
    public float movement = 10f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject snowballObject = Instantiate(snowball, transform.position, Quaternion.identity);
        snowballObject.GetComponent<Rigidbody2D>().velocity = new Vector2(movement, 0f);
    }
}
