using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _enemySpeed = 4.0f;
    private Player _player;
    private Animator _animator;
    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if(_player == null)
        {
            Debug.LogError("The Player Is Null...");
        }

        _animator = GetComponent<Animator>();
        if(_animator == null)
        {
            Debug.LogError("The animator is null....");
        }
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
            _animator.SetTrigger("OnAnimeDeath");
            _enemySpeed = 0f;
            Destroy(this.gameObject, 1.3f);
        }

        if (collision.tag == "Laser")
        {
            Destroy(collision.gameObject);
            if(_player != null)
            {
                _player.AddToScore(10);
            }
            _animator.SetTrigger("OnAnimeDeath");
            _enemySpeed = 0f;
            Destroy(this.gameObject, 1.3f);
        }
    }
}
