using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 10f)]
    [SerializeField] float secBetweenSpawns = 4f;
    [SerializeField] EnemyMovement enemyPrefab;

    void Start() {
        StartCoroutine(SpawnEnemies());
    }

    void Update() {
        
    }

    IEnumerator SpawnEnemies() {
        while(true) {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
            yield return new WaitForSeconds(secBetweenSpawns);
        }
    }
}
