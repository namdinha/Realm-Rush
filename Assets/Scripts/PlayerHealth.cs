using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int playerHealth = 10;

    void OnTriggerEnter(Collider other) {
        TakeDamage(1);
        PlayerLifeHandler();
    }

    private void PlayerLifeHandler() {
        if(playerHealth <= 0) {
            Debug.Log("END GAME");
        }
    }

    private void TakeDamage(int damage) {
        playerHealth -= damage;
    }
}
