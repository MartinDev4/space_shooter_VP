using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour {
    [SerializeField] private Text _scoreText;

    private Score _score;

    private void Awake() {
        _score = FindObjectOfType<Score>();
    }

    private void Start() {
        _scoreText.text = "You scored: \n" + _score.GetScore().ToString("000000000000");
    }
}
