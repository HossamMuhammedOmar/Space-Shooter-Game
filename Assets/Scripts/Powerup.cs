using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private float _speed = 3f;

    void Update()
    {
        MoveDown();

        if (transform.position.y <= -6.34f)
        {
            DestroyPowerup();
        }
    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    void DestroyPowerup()
    {
       Destroy(this.gameObject);
    }
}
