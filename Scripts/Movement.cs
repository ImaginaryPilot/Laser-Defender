using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] float movespeed = 10f;
    [SerializeField] float maxheigth = 0.5f;
    [SerializeField] float shoottime = 0.2f;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    [SerializeField] GameObject Laserprefab;
    [SerializeField] float projectilespeed = 10f;
    public int health = 1000;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip shootSFX;
    [SerializeField] float shootvolume = 0.7f;
    [SerializeField] float volume = 0.7f;
    void Start()
    {
        Camera gamecamera = Camera.main;
        xMin = gamecamera.ViewportToWorldPoint(new Vector3(0,0,0)).x;
        xMax = gamecamera.ViewportToWorldPoint(new Vector3(1,0,0)).x;
        yMin = gamecamera.ViewportToWorldPoint(new Vector3(0,0,0)).y;
        yMax = gamecamera.ViewportToWorldPoint(new Vector3(0,maxheigth,0)).y;
        StartCoroutine(Lasercreation());
    }

    void Update()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movespeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * movespeed;

        var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYpos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXpos, newYpos);  
    }

    IEnumerator Lasercreation()
    {
        while (true)
        {
            GameObject Laser = Instantiate(Laserprefab, transform.position, Quaternion.identity) as GameObject;
            Laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectilespeed);
            AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position, shootvolume);
            Destroy(Laser, 2);
            yield return new WaitForSeconds(shoottime);
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
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        FindObjectOfType<Level>().LoadGameOver();
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, volume);
    }
}
