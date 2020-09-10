using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8f;


    void Update()
    {
        GoUp();
        DestroyLaser();
    }

    void GoUp()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    void DestroyLaser()
    {
        if(transform.position.y >= 7.08f)
        {
            Destroy(this.gameObject);
        }
    }
}
