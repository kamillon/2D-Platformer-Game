using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleted : MonoBehaviour
{
    public GameObject go;
    public AudioSource bgSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            bgSound.Stop();
            levelCompleted();
        }
    }

    public void levelCompleted()
    {
        go.SetActive(true);

    }
}
