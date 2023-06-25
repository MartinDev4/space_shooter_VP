using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    private Vector2 _rawInput;
    [SerializeField] private float _moveSpeed = 10f;

    [SerializeField] float paddingLeft = 0.55f;
    [SerializeField] float paddingRight = 0.55f;
    [SerializeField] float paddingTop = 5f;
    [SerializeField] float paddingBottom = 2f;
    
    private Vector2 minBound;
    private Vector2 maxBound;
    private Shooter _shooter;

    private void Awake() {
        _shooter = GetComponent<Shooter>();
    }

    private void Start() {
        InitBounds();
    }

    void Update() {
        Move();
    }

    void InitBounds() {
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(Vector3.zero);
        maxBound = mainCamera.ViewportToWorldPoint(Vector3.one);
    }

    void Move() {
        Vector2 delta = _rawInput * _moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBound.x + paddingLeft, maxBound.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBound.y + paddingBottom, maxBound.y - paddingTop);

        transform.position = newPos;
    }

    void OnMove(InputValue val) {
        _rawInput = val.Get<Vector2>();
    }

    void OnFire(InputValue val) {
        if (_shooter != null) {
            _shooter.isShooting = val.isPressed;
        }
    }
}
