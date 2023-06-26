using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {
    [Header("Shooting")] 
    [SerializeField] private AudioClip _shootingSFX;
    [SerializeField] [Range(0,1)] private float _shootingVolume = .8f;

    [Header("Shooting")] 
    [SerializeField] private AudioClip _damageTakenSFX;
    [SerializeField] [Range(0, 1)] private float _damageVolume = .2f;
    

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
