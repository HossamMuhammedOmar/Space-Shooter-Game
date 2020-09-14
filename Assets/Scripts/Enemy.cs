using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _enemySpeed = 4.0f; 

    void Update()
    {
        MoveDown();
        if (transform.position.y <= -6f)
        {
           ReInintEnemy();
        }
    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _enemySpeed);
    }

    void ReInintEnemy()
    {
        float randomX = Random.Range(-9f, 9f);
        transform.position = new Vector3(randomX, 7f, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }

        if (collision.tag == "Laser")
        {
            GameObject laser = collision.gameObject;
            Destroy(laser);
            Destroy(this.gameObject);
        }
    }
}
