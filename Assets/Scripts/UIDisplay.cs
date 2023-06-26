using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour {
    [Header("Health")] 
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Health _playerHealth;
    [Header("Score")] 
    [SerializeField] private TextMeshProUGUI _scoreText;
    private Score _score;

    private void Awake() {
        _score = FindObjectOfType<Score>();
    }

    private void Start() {
        _healthSlider.maxValue = _playerHealth.GetHealth();
    }

    private void Update() {
        _healthSlider.value = _playerHealth.GetHealth();
        _scoreText.text = _score.GetScore().ToString("000000000000");
    }
}
