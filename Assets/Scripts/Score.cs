using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    private int _score;

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
