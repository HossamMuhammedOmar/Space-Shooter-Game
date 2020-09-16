using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _enemySpeed = 5.0f;
    private Player _player;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();    
    }

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
            if (_player != null)
            {
                _player.Damage();
            }
            Destroy(this.gameObject);
        }

        if (collision.tag == "Laser")
        {
            Destroy(collision.gameObject);
            if(_player != null)
            {
                _player.AddToScore(10);
            }

            Destroy(this.gameObject);
        }
    }
}
