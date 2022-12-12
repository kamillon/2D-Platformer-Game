using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public List<Transform> points;
    public int nextID = 0;
    int idChangeValue = 1;
    public float speed = 2;
    private PlayerLife playerLife;
    private ItemCollector itemCollector;
    public Transform playerTransform;
    public bool isChasing = false;

    private void Update()
    {
        if (playerTransform.transform.position.x > points[0].transform.position.x && playerTransform.transform.position.x < points[1].transform.position.x)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            if (transform.position.x > playerTransform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        else
        {
            MoveToNextPoint();
        }
    }

    void MoveToNextPoint()
    {
        Transform goalPoint = points[nextID];
        if (goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, goalPoint.position) < 0.2f)
        {
            if (nextID == points.Count - 1)
                idChangeValue = -1;
            if (nextID == 0)
                idChangeValue = 1;
            nextID += idChangeValue;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerLife = GameObject.FindObjectOfType<PlayerLife>();
            playerLife.TrapCollision();
        }
    }

    public void EnemyDeath()
    {
        itemCollector = GameObject.FindObjectOfType<ItemCollector>();
        itemCollector.distance += 100;
        Destroy(gameObject);
    }
}

