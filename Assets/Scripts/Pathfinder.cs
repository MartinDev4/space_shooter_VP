using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    [SerializeField] private WaveConfigSO waveConfig;
    private List<Transform> waypoints;
    private int waypointIndex = 0;

    void Start() {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update() {
        FollowPath();
    }

    private void FollowPath() {
        if (waypointIndex < waypoints.Count) {
            Vector3 targetPos = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, delta);
            if (targetPos == transform.position) {
                waypointIndex++;
            }
        } else {
            Destroy(gameObject);
        }
        
    }
}

