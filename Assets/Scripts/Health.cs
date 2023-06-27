using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] private bool _isPlayer;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int health = 50;
    [SerializeField] private int score = 50;
    [SerializeField] private ParticleSystem _hitEffect;

    private AudioPlayer _audioPlayer;
    private Score _score;
    private LevelManager _levelManager;
    private HealPlayer _healPlayer;
    
    private void Awake() {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _score = FindObjectOfType<Score>();
        _levelManager = FindObjectOfType<LevelManager>();
        _healPlayer = GetComponent<HealPlayer>();
        health = _maxHealth;
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

    public int GetMaxHealth() {
        return _maxHealth;
    }

    private void TakeDamage(int damageAmount) {
        health -= damageAmount;
        if (health <= 0) {
            if (_healPlayer != null) {
                _healPlayer.HealP();
            }
            Die();
        }
    }

    public void Heal(int healAmount) {
        if ((health + healAmount) <= _maxHealth) {
            health += healAmount;
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
