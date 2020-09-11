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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }

        if (other.tag == "Laser")
        {
            GameObject laser = other.gameObject;
            Destroy(laser);
            Destroy(this.gameObject);
        }
    }
}
