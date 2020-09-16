using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private float _speed = 3f;
    [SerializeField]
    private int _powerupId;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player player = collision.transform.GetComponent<Player>();

            if(player != null)
            {
                switch(_powerupId)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedPowerActive();
                        break;
                    case 2:
                        player.MakeShieldsActive();
                        break;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
