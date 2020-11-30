using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Dictionary<Waypoint, bool> exploredNeighbours = new Dictionary<Waypoint, bool>();
    Dictionary<Waypoint, Waypoint> exploredFrom = new Dictionary<Waypoint, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    List<Waypoint> path = new List<Waypoint>();
    bool isRunning;
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    private void CreatePath() {
        Waypoint current = endWaypoint;
        while(current != startWaypoint) {
            AddWaypointToPath(current);
            current = exploredFrom[current];
        }
        AddWaypointToPath(startWaypoint);
        path.Reverse();
    }

    private void AddWaypointToPath(Waypoint waypoint) {
        path.Add(waypoint);
        waypoint.isPlaceble = false;
    }

    private void BreadthFirstSearch() {
        isRunning = true;
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0 && isRunning) {
            var searchCenter = queue.Dequeue();
            HaltIfEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
            exploredNeighbours[searchCenter] = true;
        }
    }

    private void HaltIfEndFound(Waypoint searchCenter) {
        if(searchCenter == endWaypoint) {
            isRunning = false;
        }
    }

    private void ExploreNeighbours(Waypoint from) {
        if(!isRunning) { return; }
        foreach(Vector2Int direction in directions) {
            Vector2Int neighbourCoord = from.GetGridPos() + direction;
            if(grid.ContainsKey(neighbourCoord)) {
                QueueNewNeighbour(neighbourCoord, from.GetGridPos());
            }
        }
    }

    private void QueueNewNeighbour(Vector2Int neighbourCoord, Vector2Int from) {
        Waypoint neighbour = grid[neighbourCoord];
        if (!exploredNeighbours[neighbour] && !queue.Contains(neighbour)) {
            queue.Enqueue(neighbour);
            exploredFrom[neighbour] = grid[from];
        }
    }

    private void ColourStartAndEnd() {
        startWaypoint.SetTopColour(Color.green);
        endWaypoint.SetTopColour(Color.red);
    }

    private void LoadBlocks() {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints) {
            if(grid.ContainsKey(waypoint.GetGridPos())) {
                Debug.LogWarning("Overlaping Block: " + waypoint);
            }
            else {
                grid.Add(waypoint.GetGridPos(), waypoint);
                exploredNeighbours.Add(waypoint, false);
            }
        }
    }

    public List<Waypoint> GetPath() {
        if(path.Count == 0) {
            LoadBlocks();
            ColourStartAndEnd();
            BreadthFirstSearch();
            CreatePath();
        }
        return path;
    }
}
