using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 10f)]
    [SerializeField] float secBetweenSpawns = 4f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Text pointsText;
    [SerializeField] AudioClip spawnedEnemySFX;

    int playerPoints = 0;

    void Start() {
        pointsText.text = playerPoints.ToString();
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {
        while(true) {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
            AddScore();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            yield return new WaitForSeconds(secBetweenSpawns);
        }
    }

    private void AddScore() {
        playerPoints++;
        pointsText.text = playerPoints.ToString();
    }
}
