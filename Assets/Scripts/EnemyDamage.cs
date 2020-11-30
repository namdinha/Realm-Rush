using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    void Start() {
        
    }

    void OnParticleCollision(GameObject other) {
        ProcessHit();
        if(hitPoints <= 0) {
            KillEnemy();
        }
    }

    private void KillEnemy() {
        ParticleSystem death = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        death.Play();
        Destroy(gameObject);
    }

    void ProcessHit() {
        hitPoints -= 1;
        hitParticlePrefab.Play();
    }
}
