using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    public int bananas = 0;
    [SerializeField]
    private TextMeshProUGUI bananasText, scoreText, bananasGO, scoreGO, bananasLC, scoreLC;
    float previousPlayerX;
    public Transform player;
    public float distance;

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
        bananasText.text = bananas.ToString();

        scoreGO.text = "SCORE: " + distance.ToString("0");
        bananasGO.text = "x" + bananas.ToString();

        scoreLC.text = "SCORE: " + distance.ToString("0");
        bananasLC.text = "x" + bananas.ToString();
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
