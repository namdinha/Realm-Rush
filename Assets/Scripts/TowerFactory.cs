using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    Queue<Tower> towers = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint) {
        if (towers.Count < towerLimit) {
            InstantiateNewTower(baseWaypoint);
        }
        else {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void MoveExistingTower(Waypoint baseWaypoint) {
        var tower = towers.Dequeue();

        tower.waypointPosition.isPlaceble = true;
        baseWaypoint.isPlaceble = false;

        tower.ChangeTowerWaypoint(baseWaypoint);

        towers.Enqueue(tower);
    }

    private void InstantiateNewTower(Waypoint baseWaypoint) {
        var tower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity, transform);

        baseWaypoint.isPlaceble = false;

        tower.ChangeTowerWaypoint(baseWaypoint);

        towers.Enqueue(tower);
    }
}
