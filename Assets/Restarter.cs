using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Restarter : MonoBehaviour
{

    [SerializeField] GameObject controller;



    // Start is called before the first frame update
    void Start()
    {
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            controller.GetComponent<Scorekeeper>().AddPoints(-15);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
