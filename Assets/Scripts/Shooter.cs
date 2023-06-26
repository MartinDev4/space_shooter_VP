using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour {
    [Header("General")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 12f;
    [SerializeField] private float projectileLifetime = 6f;
    [SerializeField] private float baseFireRate = .25f;
    [Header("AI Configs")]
    [SerializeField] private float fireRateVariance = 0f;
    [SerializeField] private float minFireRate = .1f;
    [SerializeField] private bool useAI;

    [HideInInspector] public bool isShooting;
    private Coroutine _shootingCoroutine;
    private AudioPlayer _audioPlayer;

    private void Awake() {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start() {
        if (useAI) {
            isShooting = true;
        }
    }

    void Update() {
        Fire();
    }

    private void Fire() {
        if (isShooting && _shootingCoroutine == null) {
            _shootingCoroutine = StartCoroutine(FireContinously());
        } else if(!isShooting && _shootingCoroutine != null) {
            StopCoroutine(_shootingCoroutine);
            _shootingCoroutine = null;
        }
    }

    private IEnumerator FireContinously() {
        while (true) {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null) {
                rb.velocity = transform.up * projectileSpeed;
            }
            
            Destroy(instance, projectileLifetime);

            float timeToNextProjectile = Random.Range(baseFireRate - fireRateVariance, baseFireRate + fireRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minFireRate, float.MaxValue);
            
            _audioPlayer.PlayShootingClip();
            
            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}
