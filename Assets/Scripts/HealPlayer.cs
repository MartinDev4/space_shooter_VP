using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour {
   [SerializeField] private int _healAmount = 5;

   public void HealP() {
      Player._instance.GetComponent<Health>().Heal(_healAmount);
   }
}
