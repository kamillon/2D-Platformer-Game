using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int bananas = 0;
    private int highscore;
    [SerializeField]
    private Text bananasText;
    [SerializeField]
    private TextMeshProUGUI HighScoreText;
    [SerializeField]
    private TextMeshProUGUI YourScore;


    private void Start()
    {
        //PlayerPrefs.DeleteKey("highscore");

        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore = PlayerPrefs.GetInt("highscore");
        }
        else
        {
            highscore = 0;
        }
    }

    private void Update()
    {
        bananasText.text = "Bananas: " + bananas;
        YourScore.text = "YOUR SCORE: " + bananas;
        HighScoreText.text = "BEST SCORE: " + PlayerPrefs.GetInt("highscore");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            AudioManager.PlaySound("Banana");
            bananas++;
            SaveHighScore();
        }
    }

    public void SaveHighScore()
    {
        if(bananas > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", bananas);
        }
    }
}
