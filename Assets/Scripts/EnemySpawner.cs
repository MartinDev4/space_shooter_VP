using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] private WaveConfigSO currWave;
    
    void Start() {
        SpawnEnemies();
    }

    public WaveConfigSO GetCurrentWave() {
        return currWave;
    }

    private void SpawnEnemies() {
        for (int i = 0; i < currWave.GetEnemyCount(); i++) {
            Instantiate(currWave.GetEnemyPrefab(i), currWave.GetStartingWaypoint().position, Quaternion.identity,transform);
        }
    }
}
