using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaycastWeapon : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 10;

    public LineRenderer lineRenderer;
    public GameObject impactEffect;

    public static bool canShoot = true;

    Gradient hitGradient = new Gradient();
    Gradient missGradient = new Gradient();
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;

    void Start()
    {
        CreateHitGradient();

        CreateMissGradient();


    }

    // Update is called once per frame
    void Update()
    {
        if (PlanetController.ShotsRemaining == 0)
        {
            canShoot = false;
        }


            if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (canShoot)
            {
                StartCoroutine(Shoot());
            }
            else
            {
                Debug.Log("Out of Ammo!!!");
                //canShoot = false;
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            //if (PlanetController.ShotsRemaining == 0)#
            if (canShoot == false)
                Reload();
        }
    }

    void CreateHitGradient()
    {
        hitGradient = new Gradient();

        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[2];
        colorKey[0].color = Color.green;
        colorKey[0].time = 0.0f;
        colorKey[1].color = Color.green;
        colorKey[1].time = 1.0f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 0.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 0.8f;
        alphaKey[1].time = 1.0f;

        hitGradient.SetKeys(colorKey, alphaKey);
    }

    void CreateMissGradient()
    {
        missGradient = new Gradient();

        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[2];
        colorKey[0].color = Color.red;
        colorKey[0].time = 0.0f;
        colorKey[1].color = Color.red;
        colorKey[1].time = 1.0f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 1.0f;

        missGradient.SetKeys(colorKey, alphaKey);
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.tag == "Hexagon") // Check if you're hitting a hexagon, not the safe space or emtpy space
            {
                Hexagon hexagon = hitInfo.transform.GetComponent<Hexagon>(); //check it's live
                if (hexagon != null)
                {
                    PlanetController.ShotsRemaining--; //change ammo
                    hexagon.TakeDamage(damage); //desstroy hexagon

                    RenderHit(hitInfo); //render laser  beam for hit
                }
                
            }
            else //if doesn't hit
            {
                RenderMiss();
            }

            lineRenderer.enabled = true;

            yield return new WaitForSeconds(0.02f);

            lineRenderer.enabled = false;
        }
    }

   void RenderHit(RaycastHit2D hitInfo)
    {
        lineRenderer.colorGradient = hitGradient;
        lineRenderer.SetPosition(0, firePoint.position);
        GameObject effectIns = (GameObject)Instantiate(impactEffect, hitInfo.point, hitInfo.transform.rotation);
        lineRenderer.SetPosition(1, hitInfo.point);
        Destroy(effectIns, 1.5f);
    }

   void RenderMiss()
    {
        lineRenderer.colorGradient = missGradient;
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 50);
    }

   void Reload()
    {
        PlanetController.ShotsRemaining = PlanetController.ShotsRemaining + 3;
        canShoot = true;
        Debug.Log("Reloading!");
    }

}