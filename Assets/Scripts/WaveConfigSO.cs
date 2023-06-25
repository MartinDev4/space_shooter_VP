using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject {

    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private float moveSpeed = 7f;

    public Transform GetStartingWaypoint() {
        return pathPrefab.GetChild(0);
    }

    public int GetEnemyCount() {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index) {
        if (index < GetEnemyCount()) {
            return enemyPrefabs[index];
        }

        return enemyPrefabs[0];
    }

    public List<Transform> GetWaypoints() {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab) {
            waypoints.Add(child);
        }

        return waypoints;
    }
    
    public float GetMoveSpeed() {
        return moveSpeed;
    }
}
