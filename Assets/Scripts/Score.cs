using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    private int _score;
    private static Score _instance;

    private void Awake() {
        ManageSingleton();
    }

    private void ManageSingleton() {
        if (_instance != null) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore() {
        return _score;
    }

    public void AddScore(int amount) {
        _score += amount;
        Mathf.Clamp(_score, 0, int.MaxValue);
    }

    public void ResetScore() {
        _score = 0;
    }
}
