using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SurvivorUI : MonoBehaviour
{
    //public Text
    public TextMeshProUGUI survivorText;
    public TextMeshProUGUI cooldownText;

    public float animSpeedInSec = 1f;
    bool keepAnimating = false;

    // Update is called once per frame
    void Update()
    {
        survivorText.text = "x " + PlanetController.Lives;
       
        AmmoCheck();       
    }

    void AmmoCheck()
    {
        if(RaycastWeapon.canShoot == false)
        {
            cooldownText.color = Color.red;
            startTextMeshAnimation();
        }
        else
        {
            cooldownText.color = Color.white;
            stopTextMeshAnimation();
        }

        cooldownText.text = "Shots Remaining: " + PlanetController.ShotsRemaining;
    }


    

    private IEnumerator anim()
    {

        Color currentColor = cooldownText.color;

        Color invisibleColor = cooldownText.color;
        invisibleColor.a = 0; //Set Alpha to 0

        float oldAnimSpeedInSec = animSpeedInSec;
        float counter = 0;
        while (keepAnimating)
        {
            //Hide Slowly
            while (counter < oldAnimSpeedInSec)
            {
                if (!keepAnimating)
                {
                    yield break;
                }

                //Reset counter when Speed is changed
                if (oldAnimSpeedInSec != animSpeedInSec)
                {
                    counter = 0;
                    oldAnimSpeedInSec = animSpeedInSec;
                }

                counter += Time.deltaTime;
                cooldownText.color = Color.Lerp(currentColor, invisibleColor, counter / oldAnimSpeedInSec);
                yield return null;
            }

            yield return null;


            //Show Slowly
            while (counter > 0)
            {
                if (!keepAnimating)
                {
                    yield break;
                }

                //Reset counter when Speed is changed
                if (oldAnimSpeedInSec != animSpeedInSec)
                {
                    counter = 0;
                    oldAnimSpeedInSec = animSpeedInSec;
                }

                counter -= Time.deltaTime;
                cooldownText.color = Color.Lerp(currentColor, invisibleColor, counter / oldAnimSpeedInSec);
                yield return null;
            }
        }
    }

    //Call to Start animation
    void startTextMeshAnimation()
    {
        if (keepAnimating)
        {
            return;
        }
        keepAnimating = true;
        StartCoroutine(anim());
    }

    //Call to Change animation Speed
    void changeTextMeshAnimationSpeed(float animSpeed)
    {
        animSpeedInSec = animSpeed;
    }

    //Call to Stop animation
    void stopTextMeshAnimation()
    {
        keepAnimating = false;
    }

}
