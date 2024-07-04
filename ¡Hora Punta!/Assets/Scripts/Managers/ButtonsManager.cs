using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject creditsPanel;
    public GameObject audioPanel;
    public GameObject fundacionesPanel;
    public GameObject tutorialPanel;
    public GameObject ButtonsGroup;

    public AudioManager audioManager;

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

    public void OpenFundaciones()
    {
        fundacionesPanel.SetActive(true);
        ButtonsGroup.SetActive(false);
    }

    public void OpenSound()
    {
        audioPanel.SetActive(true);
        ButtonsGroup.SetActive(false);
    }

    public void CloseSound()
    {
        audioPanel.SetActive(false);
        ButtonsGroup.SetActive(true);
    }

    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
        ButtonsGroup.SetActive(false);
    }

    public void CloseCredits()
    {
        ButtonsGroup.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void closeFundaciones()
    {
        fundacionesPanel.SetActive(false);
        ButtonsGroup.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenTutorial()
    {
        tutorialPanel.SetActive(true);

    }

    public void CloseTutorial()
    {
        tutorialPanel.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
