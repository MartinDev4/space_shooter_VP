using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {
    [Header("Shooting")] 
    [SerializeField] private AudioClip _shootingSFX;
    [SerializeField] [Range(0,1)] private float _shootingVolume = .8f;

    [Header("Shooting")] 
    [SerializeField] private AudioClip _damageTakenSFX;
    [SerializeField] [Range(0, 1)] private float _damageVolume = .2f;

    private static AudioPlayer _instance;
    
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

    public void PlayShootingClip() {
        PlayClip(_shootingSFX, _shootingVolume);
    }

    public void PlayDamageTakenClip() {
        PlayClip(_damageTakenSFX, _damageVolume);
    }

    void PlayClip(AudioClip clip, float volume) {
        if (clip != null) {
            if (Camera.main != null) {
                Vector3 cameraPos = Camera.main.transform.position;
                AudioSource.PlayClipAtPoint(clip,cameraPos,volume);
            }
        }
    }
}
