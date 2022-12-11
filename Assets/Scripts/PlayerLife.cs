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
    public GameObject player;
    public Transform respawnPoint;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            TrapCollision();
        }

        if (other.gameObject.CompareTag("KillZone"))
        {
            if (!isDead)
            {
                HealthManager.health--;
                if (HealthManager.health <= 0 && !isDead)
                {
                    bgSound.Stop();
                    isDead = true;
                    gameManager.gameOver();
                }
                else
                {
                    player.transform.position = respawnPoint.position;
                }
            }
        }
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(13,14);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(1);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(13,14, false);
    }

    public void TrapCollision()
    {
        if (!isDead)
        {
            HealthManager.health--;
            if (HealthManager.health <= 0 && !isDead)
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
    }

    public void Die()
    {
        rb.velocity = Vector3.zero;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().enabled = false;
        anim.SetTrigger("death");  
    }
}
