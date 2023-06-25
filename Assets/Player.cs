using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    private Vector2 _rawInput;
    [SerializeField] private float _moveSpeed = 7.5f;
    
    void Update() {
        Move();
    }

    void Move() {
        Vector3 delta = _rawInput * _moveSpeed * Time.deltaTime;
        transform.position += delta;
    }

    void OnMove(InputValue val) {
        _rawInput = val.Get<Vector2>();

    }
}
