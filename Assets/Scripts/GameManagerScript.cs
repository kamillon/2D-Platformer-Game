using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject go;

    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        //if (go.activeInHierarchy)
        //{
        //    Cursor.visible = true;
        //    Cursor.lockState = CursorLockMode.None;
        //}
        //else
        //{
        //    Cursor.visible = false;
        //    Cursor.lockState = CursorLockMode.Locked;
        //}
    }

    public void gameOver()
    {
        go.SetActive(true);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().enabled = false;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void tryAgain()
    {
        SceneManager.LoadScene("Level1");
    }

    public void quit()
    {
        Application.Quit();
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void controls()
    {
        SceneManager.LoadScene("Controls");
    }

}
