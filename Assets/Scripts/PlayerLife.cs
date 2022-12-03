using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private bool isDead;
    public GameManagerScript gameManager;
    public AudioSource bgSound;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Trap"))
    //    {
    //        Die();
    //    }

    //    if (collision.gameObject.CompareTag("KillZone"))
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            HealthManager.health--;
            if(HealthManager.health <= 0 && !isDead)
            {
                bgSound.Stop();
                isDead = true;
                Die();
                gameManager.gameOver();
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }


        if (collision.gameObject.CompareTag("KillZone"))
        {
            if (!isDead)
            {
                bgSound.Stop();
                isDead = true;
                gameManager.gameOver();
            }
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(13,14);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(2);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(13,14, false);
    }


    private void Die()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().enabled = false;
        anim.SetTrigger("death");  
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
