using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float shootCounter;
    [SerializeField] private float minTimeBetweenShoots = 0.3f;
    [SerializeField] private float maxTimeBetweenShoots = 3f;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float laserSpeed = 15;
    [SerializeField] private GameObject destroyVFX;
    [SerializeField] private float destroyVFXDelay = 2f;
    
    
    
    

    private void Start()
    {
        SetupShootCounter();
    }
    
    private void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shootCounter -= Time.deltaTime;
        if (shootCounter <= 0)
            Fire();
    }

    private void Fire()
    {
        var laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
        
        SetupShootCounter();
    }
    
    private void SetupShootCounter()
    {
        shootCounter = Random.Range(minTimeBetweenShoots, maxTimeBetweenShoots);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        if (damageDealer == null)
            return;
        
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
        var destroyVfxObject = Instantiate(destroyVFX, transform.position, transform.rotation);
        Destroy(destroyVfxObject, destroyVFXDelay);
    }
}
