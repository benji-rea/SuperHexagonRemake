using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static bool isSafe = false;

    public float moveSpeed = 600f;
    float movement = 0f;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        movement = Input.GetAxisRaw("Horizontal");

    }

    void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * -moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Made it through the gap
        if (collision.tag == "Safe")
        {
            Debug.Log("Safe!");

            isSafe = true;

        }
    }
}
