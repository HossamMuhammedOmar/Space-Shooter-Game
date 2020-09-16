using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Sprite[] _livesSprites;
    [SerializeField]
    private Image _livesImg;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;

    void Start()
    {
        _livesImg.sprite = _livesSprites[3];
        _gameOverText.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
        _scoreText.text = "Score: " + 0;
    }

    public void SetScore(int score)
    {
        _scoreText.text = "Score: " + score;
    }
    public void UpdateLives(int currentLive)
    {
        _livesImg.sprite = _livesSprites[currentLive];

        if (currentLive == 0)
        {
            GameOverSequnce();
        }
    }

    void GameOverSequnce()
    {
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameoverFlicker());
    }

    IEnumerator GameoverFlicker()
    {
        while (true)
        {
            _gameOverText.text = "GAME OVER";
            _restartText.text = "Press 'R' to restart the game";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            _restartText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
