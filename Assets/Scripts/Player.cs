using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    private float _multiplySpeed = 2f;
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
    private bool _isSpeedPoweActive = false;
    [SerializeField]
    private bool _isShieldActive = false;
    [SerializeField]
    private GameObject _shiledPlayer;
    [SerializeField]
    private int _score;
    private UI_Manager ui_manager;
    private GameManager gameManager;
    [SerializeField]
    private GameObject[] _playerEngins;
    [SerializeField]
    private AudioSource _laserAudio;

    void Start()
    {
        ui_manager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();


        if(ui_manager == null)
        {
            Debug.Log("The UI Manager equale null");
        }

        if(gameManager == null)
        {
            Debug.Log("The Game Manager equale null");
        }

        transform.position = new Vector3(0, 0, 0);
        spwanManager = GameObject.Find("Spwan_Manager").GetComponent<Spwan_Manager>();
    }

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
            _laserAudio.Play();

            if (_isTripleActive)
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
        transform.Translate(deriction * _speed * Time.deltaTime);
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
        if(_isShieldActive)
        {
            _shiledPlayer.SetActive(false);
            _isShieldActive = false;
            return;
        }

        _lives --;
        ui_manager.UpdateLives(_lives);

        switch (_lives)
        {
            case 2:
                _playerEngins[0].SetActive(true);
                break;
            case 1:
                    _playerEngins[1].SetActive(true);
                break;
        }

        if(_lives < 1)
        {
            spwanManager.OnPlayerDeath();
            Destroy(this.gameObject);
            gameManager.GameOver();
        }
    }

    public void TripleShotActive()
    {
        _isTripleActive = true;
        StartCoroutine(SetTrippleActive());
    }

    IEnumerator SetTrippleActive()
    {
        yield return new WaitForSeconds(5f);
        _isTripleActive = false;
    }

    public void SpeedPowerActive()
    {
        _isSpeedPoweActive = true;
        _speed *= _multiplySpeed;
        StartCoroutine(setSpeedPowerActive());
    }

    IEnumerator setSpeedPowerActive()
    {
        yield return new WaitForSeconds(5f);
        _isSpeedPoweActive = false;
        _speed /= _multiplySpeed;
    }

    public void MakeShieldsActive()
    {
        _shiledPlayer.SetActive(true);
        _isShieldActive = true;
    }

    public void AddToScore(int points)
    {
        _score += points;
        ui_manager.SetScore(_score);
    }
}
