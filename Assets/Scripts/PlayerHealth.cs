using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int playerHealth = 10;
    [SerializeField] Text healthText;

    void Start() {
        healthText.text = playerHealth.ToString();
    }

    void OnTriggerEnter(Collider other) {
        TakeDamage(1);
        healthText.text = playerHealth.ToString();
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
