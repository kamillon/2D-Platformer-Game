using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<Transform> points;
    public int nextID = 0;
    int idChangeValue = 1;
    public float speed = 2;
    private PlayerLife playerLife;
    private ItemCollector itemCollector;


    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        Transform goalPoint = points[nextID];
        if (goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
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
