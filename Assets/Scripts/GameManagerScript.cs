using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject go;

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
