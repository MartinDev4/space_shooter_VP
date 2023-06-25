using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] private int health = 50;

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer dmgDealer = other.GetComponent<DamageDealer>();

        if (dmgDealer != null) {
            TakeDamage(dmgDealer.GetDamage());
            dmgDealer.Hit();
        }
    }

    private void TakeDamage(int damageAmount) {
        health -= damageAmount;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
