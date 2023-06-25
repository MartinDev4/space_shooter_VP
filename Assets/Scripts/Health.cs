using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] private int health = 50;
    [SerializeField] private ParticleSystem _hitEffect; 

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer dmgDealer = other.GetComponent<DamageDealer>();

        if (dmgDealer != null) {
            TakeDamage(dmgDealer.GetDamage());
            PlayHitEffect();
            dmgDealer.Hit();
        }
    }

    private void TakeDamage(int damageAmount) {
        health -= damageAmount;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    void PlayHitEffect() {
        if (_hitEffect !=  null) {
            ParticleSystem instance = Instantiate(_hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
