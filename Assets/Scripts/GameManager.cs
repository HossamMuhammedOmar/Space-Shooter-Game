﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver = false;

    private void Update()
    {
        RestartGame();
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    void RestartGame()
    {
        if(Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            SceneManager.LoadScene(1);
            _isGameOver = false;
        }
    }
}
