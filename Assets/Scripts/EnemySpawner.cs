using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 10f)]
    [SerializeField] float secBetweenSpawns = 4f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Text pointsText;

    int playerPoints = 0;

    void Start() {
        pointsText.text = playerPoints.ToString();
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {
        while(true) {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
            playerPoints++;
            pointsText.text = playerPoints.ToString();
            yield return new WaitForSeconds(secBetweenSpawns);
        }
    }
}
