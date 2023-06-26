using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] private bool _isPlayer;
    [SerializeField] private int health = 50;
    [SerializeField] private int score = 50;
    [SerializeField] private ParticleSystem _hitEffect;

    private AudioPlayer _audioPlayer;
    private Score _score;
    private LevelManager _levelManager;
    
    private void Awake() {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _score = FindObjectOfType<Score>();
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer dmgDealer = other.GetComponent<DamageDealer>();

        if (dmgDealer != null) {
            TakeDamage(dmgDealer.GetDamage());
            PlayHitEffect();
            _audioPlayer.PlayDamageTakenClip();
            dmgDealer.Hit();
        }
    }

    public int GetHealth() {
        return health;
    }

    private void TakeDamage(int damageAmount) {
        health -= damageAmount;
        if (health <= 0) {
            Die();
        }
    }

    private void Die() {
        if (!_isPlayer) {
            _score.AddScore(score);
        } else {
            _levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }

    void PlayHitEffect() {
        if (_hitEffect !=  null) {
            ParticleSystem instance = Instantiate(_hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
