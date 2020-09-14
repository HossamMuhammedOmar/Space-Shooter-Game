using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.15f;
    private float _canFire = -1f;
    private int _lives = 3;
    private Spwan_Manager spwanManager;
    private bool _isTripleActive = false;
    [SerializeField]
    private GameObject _laserTriplePrefab;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        spwanManager = GameObject.Find("Spwan_Manager").GetComponent<Spwan_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementPlayer();
        SpwanLaser();
    }


    void SpwanLaser()
    {
        Vector3 offsit = new Vector3(transform.position.x, transform.position.y + 1.05f, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;

            if(_isTripleActive)
            {
                Instantiate(_laserTriplePrefab, transform.position, Quaternion.identity);
            } else
            {
                Instantiate(_laserPrefab, offsit, Quaternion.identity);
            }
        }
    }

    void MovementPlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 deriction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(deriction * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.961581f, 0f), 0);

        if (transform.position.x >= 11f)
        {
            transform.position = new Vector3(-11f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.25f)
        {
            transform.position = new Vector3(11f, transform.position.y, 0);
        }
    }

    public void Damage()
    {
        _lives --;

        if(_lives < 1)
        {
            spwanManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "TripleShot")
        {
            Destroy(collision.gameObject);
            StartCoroutine(TripleShotActive());
        }
    }

    IEnumerator TripleShotActive()
    {
        _isTripleActive = true;
        yield return new WaitForSeconds(5f);
        _isTripleActive = false;
    }
}
