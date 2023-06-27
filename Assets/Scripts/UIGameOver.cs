using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour {
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _highScoreText;

    private Score _score;

    private void Awake() {
        _score = FindObjectOfType<Score>();
    }

    private void Start() {
        int highScore = PlayerPrefs.GetInt("HighScore");
        _scoreText.text = "You scored: \n" + _score.GetScore().ToString("000000000000");
        _highScoreText.text = "Your high score: \n" + highScore.ToString("000000000000");
    }
}
