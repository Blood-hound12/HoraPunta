using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject HowToPlayPanel;

    public AudioManager audioManager;

    private void Awake()
    {
        HowToPlayPanel.SetActive(true);
    }

    public void PlayOrRestart()
    {
        SceneManager.LoadScene("Test");
    }

    public void OpenOptions(GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);

        panel.SetActive(true);
        audioManager.PlaySoundButton(); 
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
