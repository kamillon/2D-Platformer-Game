using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    public int bananas = 0;
    [SerializeField]
    private TextMeshProUGUI bananasText;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI HighScoreText;
    [SerializeField]
    private TextMeshProUGUI YourScore;

    float previousPlayerX;
    public Transform player;
    private float distance;


    void Awake()
    {
        previousPlayerX = player.position.x;
        distance = 0;
    }

    private void Update()
    {

        if (previousPlayerX < player.position.x)
        {
            distance += (player.position.x - previousPlayerX) * 10;
            previousPlayerX = player.transform.position.x;
        }

        scoreText.text = "Score: " + distance.ToString("0");
        bananasText.text = "Bananas: " + bananas;

        YourScore.text = "YOUR SCORE: " + distance.ToString("0");
        HighScoreText.text = "Bananas: " + bananas;
        HighScoreText.text = "BEST SCORE: " + PlayerPrefs.GetInt("highscore");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            AudioManager.PlaySound("Pickup");
            bananas++;
        }
    }
}
