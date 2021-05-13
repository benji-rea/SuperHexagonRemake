using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainLevel";

    public ParticleSystem MenuParticles;
    public GameObject settingsUI;
    public GameObject menuUI;
    public GameObject guideUI;

    public AudioSource audioSource;
    public AudioClip audioClip;

    void Start()
    {   
        MenuParticles = GetComponent<ParticleSystem>();      
    }

    // Start is called before the first frame update
    public void PlayButton()
    {
        PlayClick();

        Destroy(MenuParticles);
        Time.timeScale = 1f;

        if (!MenuParticles)
        Debug.Log("Particles Deleted");
                
        SceneManager.LoadScene(levelToLoad);
    }

    private void PlayClick()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    // Update is called once per frame
    public void Quit()
    {
        PlayClick();

        Debug.Log("Exiting...");
        Application.Quit();
    }


    public void ToggleSettings()
    {
        PlayClick();
        menuUI.SetActive(!menuUI.activeSelf);
        settingsUI.SetActive(!settingsUI.activeSelf);
    }

    public void ToggleGuide()
    {
        PlayClick();
        menuUI.SetActive(!menuUI.activeSelf);
        guideUI.SetActive(!guideUI.activeSelf);
    }

    public void ReturnToMenu()
    {
        PlayClick();
        guideUI.SetActive(false);
        settingsUI.SetActive(false);
        menuUI.SetActive(true);
    }
}
