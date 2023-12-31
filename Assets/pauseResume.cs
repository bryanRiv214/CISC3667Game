using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseResume : MonoBehaviour
{

    [SerializeField] GameObject[] pauseMode;
    [SerializeField] GameObject[] resumeMode;
    // Start is called before the first frame update
    void Start()
    {
        pauseMode = GameObject.FindGameObjectsWithTag("ShowInPause");
        resumeMode = GameObject.FindGameObjectsWithTag("ShowInResume");

        ResumeMode();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        PauseMode();

    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        ResumeMode();

    }

    public void PauseMode()
    {

        foreach (GameObject g in pauseMode)
            g.SetActive(true);

        foreach (GameObject g in resumeMode)
            g.SetActive(false);
    }

    public void ResumeMode()
    {

        foreach (GameObject g in pauseMode)
            g.SetActive(false);

        foreach (GameObject g in resumeMode)
            g.SetActive(true);
    }
}
