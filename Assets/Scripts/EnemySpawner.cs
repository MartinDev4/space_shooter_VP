using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] private List<WaveConfigSO> waveConfigs;
    [SerializeField] private float timeBetweenWaves = 0.5f;
    [SerializeField] private bool isLooping;
    private WaveConfigSO currWave;
    
    void Start() {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave() {
        return currWave;
    }

    IEnumerator SpawnEnemyWaves() {
        do {
            foreach (var wave in waveConfigs) {
                currWave = wave;
                for (int i = 0; i < currWave.GetEnemyCount(); i++) {
                    Instantiate(currWave.GetEnemyPrefab(i), currWave.GetStartingWaypoint().position,
                        Quaternion.identity, transform);
                    yield return new WaitForSeconds(currWave.GetRandomSpawnTime());
                }

                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);


    }
}
