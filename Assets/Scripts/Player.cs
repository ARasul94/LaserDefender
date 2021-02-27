using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Moving")]
    [SerializeField] private float speed;
    [SerializeField] private float padding;
    [Header("Fire")]
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float laserSpeed;
    [SerializeField] private float fireSpeed;
    [Header("Player")] 
    [SerializeField] private float health = 200;
    [Header("Destroy")]
    [SerializeField] private GameObject destroyVFX;
    [SerializeField] private float destroyVFXDelay = 2f;
    [Header("Sounds")] 
    [SerializeField] private AudioClip deathSound;
    [SerializeField][Range(0,1)] private float deathSoundVolume = 0.5f;
    [SerializeField] private AudioClip shootSound;
    [SerializeField][Range(0,1)] private float shootSoundVolume = 0.05f;

    private Vector2 _minBoundary;
    private Vector2 _maxBoundary;
    private Coroutine _fireContinuously;
    private Level _level;
    private Camera _camera;


    private void Awake()
    {
        _level = FindObjectOfType<Level>();
        if (_level == null)
            throw new Exception($"No Level gameobject on scene {SceneManager.GetActiveScene().name}");
        
        _camera = Camera.main;
        if (_camera == null)
            throw new Exception($"No Camera gameobject on scene {SceneManager.GetActiveScene().name}");
    }

    private void Start()
    {
        SetupBoundaries();
    }

    private void Update()
    {
        Move();
        Fire();
    }

    private void Move()
    {
        var position = transform.position;
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var newXPos = Mathf.Clamp(position.x + deltaX, _minBoundary.x, _maxBoundary.x);
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        var newYPos = Mathf.Clamp(position.y + deltaY, _minBoundary.y, _maxBoundary.y);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (_fireContinuously != null)
            {
                StopCoroutine(_fireContinuously);
                _fireContinuously = null;
            }

            _fireContinuously = StartCoroutine(FireContinuously());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            if (_fireContinuously == null) 
                return;
            StopCoroutine(_fireContinuously);
            _fireContinuously = null;
        }
    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            var laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
            PlaySFX(shootSound, shootSoundVolume);

            yield return new WaitForSeconds(fireSpeed);
        }
    }
    
    private void SetupBoundaries()
    {
        var leftBotCorner = _camera.ViewportToWorldPoint(new Vector2(0, 0));
        var rightTopCorner = _camera.ViewportToWorldPoint(new Vector2(1, 1));

        _minBoundary = new Vector2(leftBotCorner.x + padding, leftBotCorner.y + padding);
        _maxBoundary = new Vector2(rightTopCorner.x - padding, rightTopCorner.y - padding);
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
        PlaySFX(deathSound, deathSoundVolume);
        PlayVFX();
        _level.LoadGameOverScene();
    }

    private void PlaySFX(AudioClip soundToPlay, float volume)
    {
        AudioSource.PlayClipAtPoint(soundToPlay, _camera.transform.position, volume);
    }

    private void PlayVFX()
    {
        var destroyVfxObject = Instantiate(destroyVFX, transform.position, transform.rotation);
        Destroy(destroyVfxObject, destroyVFXDelay);
    }
}
