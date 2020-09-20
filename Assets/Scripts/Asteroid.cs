using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float _rotateSpeed = 20.0f;
    [SerializeField]
    private GameObject _explosion;
    private Spwan_Manager _spwanManager;

    private void Start()
    {
        _spwanManager = GameObject.Find("Spwan_Manager").GetComponent<Spwan_Manager>();    
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, _rotateSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Laser")
        {
            Destroy(collision.gameObject);
            this.gameObject.SetActive(false);
            Instantiate(_explosion, transform.position, Quaternion.identity);
            _spwanManager.StartSpwaning();
            Destroy(this.gameObject, 0.5f);
        }
    }
}
