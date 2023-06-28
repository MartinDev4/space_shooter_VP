using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    [SerializeField] private float _sceneLoadDelay = 2f;
    private Score _score;

    private void Start() {
        _score = Score._instance;
    }

    public void LoadGame() {
        _score.ResetScore();
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadMainMenu() {
        SceneManager.LoadSceneAsync(0);
    }

    public void LoadGameOver() {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScore < _score.GetScore()) {
            PlayerPrefs.SetInt("HighScore", _score.GetScore());
        }
        
        StartCoroutine(WaitAndLoad(2, _sceneLoadDelay));
    }

    public void QuitGame() {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(int sceneIndex, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }
}
