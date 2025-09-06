using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 500;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject Explosion;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip shootSFX;
    [SerializeField] float volume = 0.7f;
    [SerializeField] float shootvolume = 0.5f;
    [SerializeField] int scoreValue = 150;
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            GameObject laser = Instantiate(
           projectile,
           transform.position,
           Quaternion.identity
           ) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
            AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, volume);
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damagedealer damagedealer = other.gameObject.GetComponent<Damagedealer>();
        if (!damagedealer) { return; }
        health -= damagedealer.GetDamage();
        damagedealer.Hit();
        if (health <= 0)
        {
            FindObjectOfType<GameSession>().AddScore(scoreValue);
            GameObject Exploded = Instantiate(Explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(Exploded, 1f);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position, shootvolume);
        }
    }
}
