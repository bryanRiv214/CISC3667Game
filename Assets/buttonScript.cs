using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class buttonScript : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void PlayGame()
    {
        string s = nameInput.text;
        if (s == "")
        {
            s = "Anonymous";
        }
        Debug.Log("your name is: " + s);
        //store in persistent data
        PersistentData.Instance.SetName(s);
        SceneManager.LoadScene("Level1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void HighScores()
    {
        SceneManager.LoadScene("HiScores");
    }

}
