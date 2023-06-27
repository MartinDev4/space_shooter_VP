using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour {
   [SerializeField] private int _healAmount = 5;
   
   private Player _player;
   private Health _playerHealth;

   private void Awake() {
      _player = FindObjectOfType<Player>();
      _playerHealth = _player.GetComponent<Health>();
   }

   public void HealP() {
      _playerHealth.Heal(_healAmount);
   }
}
