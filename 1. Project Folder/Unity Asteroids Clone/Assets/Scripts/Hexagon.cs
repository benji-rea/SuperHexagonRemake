using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    public Rigidbody2D rb;

    public int health = 20;
    public float shrinkSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb.rotation = Random.Range(0f, 360f);
        transform.localScale = Vector3.one * 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

        if (transform.localScale.x <= .1f)
        {
            HitPlanet();
        }
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void HitPlanet()
    {
        if (PlayerController.isSafe)
        {
            PlayerController.isSafe = false;
            Die();
            return;
        }

        if (!GameManager.GameIsOver)
        {
            PlanetController.Lives -= Random.Range(1, 100);
        }
        
        Die();
    }


    void Die()
    {
        Destroy(gameObject);
    }
}
