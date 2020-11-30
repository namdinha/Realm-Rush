using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemyDamageSFX;
    [SerializeField] AudioClip enemyDeathSFX;

    void Start() {
        
    }

    void OnParticleCollision(GameObject other) {
        ProcessHit();
        if(hitPoints <= 0) {
            KillEnemy();
        }
    }

    private void KillEnemy() {
        ParticleSystem vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position, 0.1f);
        float destroyDelay = vfx.main.duration;
        Destroy(vfx.gameObject, destroyDelay);
        Destroy(gameObject);
    }

    void ProcessHit() {
        hitPoints -= 1;
        hitParticlePrefab.Play();
        GetComponent<AudioSource>().PlayOneShot(enemyDamageSFX);
    }
}
