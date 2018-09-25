using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject canvas;
    public bool pressedStart;
    public AudioSource music;

    private bool isStartMenu;

    private void Start()
    {
        canvas = GameObject.Find("Canvas");
        pressedStart = false;
        isStartMenu = SceneManager.GetActiveScene().name == "StartMenu";
        if (isStartMenu) {
            music = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
        }
    }

    public void PlayGame()
    {
        pressedStart = true;
        canvas.transform.GetChild(1).gameObject.SetActive(false);
        canvas.transform.GetChild(2).gameObject.SetActive(false);
        canvas.transform.GetChild(3).gameObject.SetActive(false);
        canvas.transform.GetChild(4).gameObject.SetActive(false);
        canvas.transform.GetChild(5).gameObject.SetActive(true);
        canvas.transform.GetChild(8).gameObject.SetActive(false);
    }

    public void AboutGame()
    {
        canvas.transform.GetChild(2).gameObject.SetActive(false);
        canvas.transform.GetChild(3).gameObject.SetActive(false);
        canvas.transform.GetChild(4).gameObject.SetActive(false);
        canvas.transform.GetChild(6).gameObject.SetActive(true);
        canvas.transform.GetChild(7).gameObject.SetActive(true);
    }

    public void Back()
    {
        canvas.transform.GetChild(2).gameObject.SetActive(true);
        canvas.transform.GetChild(3).gameObject.SetActive(true);
        canvas.transform.GetChild(4).gameObject.SetActive(true);
        canvas.transform.GetChild(6).gameObject.SetActive(false);
        canvas.transform.GetChild(7).gameObject.SetActive(false);
    }

    void Update()
    {
        if (pressedStart && Input.GetKeyDown(KeyCode.Space))
        {
            if (isStartMenu) {
                DontDestroyOnLoad(music);
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
