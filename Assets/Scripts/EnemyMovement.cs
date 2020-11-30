using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float movementPeriod = 1f;
    [SerializeField] ParticleSystem finishParticlePrefab;

    void Start() {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(MoveThruWaypoints(path));
    }

    IEnumerator MoveThruWaypoints(List<Waypoint> path) {
        foreach (Waypoint waypoint in path) {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        FinishPath();
    }

    private void FinishPath() {
        ParticleSystem vfx = Instantiate(finishParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;
        Destroy(vfx.gameObject, destroyDelay);

        Destroy(gameObject);
    }
}
