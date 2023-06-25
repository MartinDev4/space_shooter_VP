using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {
    [SerializeField] private Vector2 moveSpeed;

    private Vector2 _offset;
    private Material _material;
    
    void Awake() {
        _material = GetComponent<SpriteRenderer>().material;
    }

    void Update() {
        _offset = moveSpeed * Time.deltaTime;
        _material.mainTextureOffset += _offset;
    }
}
