using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [Header("Enemy stats")]
    [SerializeField] private float health;
    [SerializeField] private int scoreForKill = 100;
    [Header("Fire")]
    [SerializeField] private float shootCounter;
    [SerializeField] private float minTimeBetweenShoots = 0.3f;
    [SerializeField] private float maxTimeBetweenShoots = 3f;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float laserSpeed = 10;
    [Header("Destroy")]
    [SerializeField] private GameObject destroyVFX;
    [SerializeField] private float destroyVFXDelay = 2f;
    [Header("Sounds")] 
    [SerializeField] private AudioClip deathSound;
    [SerializeField][Range(0,1)] private float deathSoundVolume = 0.5f;
    [SerializeField] private AudioClip shootSound;
    [SerializeField][Range(0,1)] private float shootSoundVolume = 0.05f;
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
        PlaySFX(shootSound, shootSoundVolume);
        
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
        FindObjectOfType<GameSession>().AddScore(scoreForKill);
        Destroy(gameObject);
        PlaySFX(deathSound, deathSoundVolume);
        PlayVFX();
    }

    private void PlaySFX(AudioClip soundToPlay, float volume)
    {
        AudioSource.PlayClipAtPoint(soundToPlay, Camera.main.transform.position, volume);
    }

    private void PlayVFX()
    {
        var destroyVfxObject = Instantiate(destroyVFX, transform.position, transform.rotation);
        Destroy(destroyVfxObject, destroyVFXDelay);
    }
}
