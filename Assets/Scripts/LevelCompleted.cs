using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    public GameObject go;
    public AudioSource bgSound;
    private bool levelCompleted = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !levelCompleted){
            bgSound.Stop();
            levelCompleted = true;
            levelCompletedScreen();
            //Invoke("nextLevel", 2f);
            //nextLevel();
        }
    }

    public void levelCompletedScreen()
    {
        go.SetActive(true);

    }

    //public void nextLevel()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}
}
