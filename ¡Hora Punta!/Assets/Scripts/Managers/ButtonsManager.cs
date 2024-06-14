using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject creditsPanel;
    public GameObject HowToPlayPanel;
    public GameObject peopeoaudio;

    public AudioManager audioManager;

    private void Awake()
    {
        HowToPlayPanel.SetActive(true);
    }

    public void PlayOrRestart()
    {
        SceneManager.LoadScene("Test");
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
        Time.timeScale = 0;
        audioManager.PlaySoundButton(); 
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenSound()
    {
        peopeoaudio.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseSound()
    {
        peopeoaudio.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitHowToPlay()
    {
        HowToPlayPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
