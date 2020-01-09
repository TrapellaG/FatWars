using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public Button play;
    public Button options;
    public Button credits;
    public Button exit;
    public Button returnToMenuO;
    public Button returnToMenuC;

    public GameObject menuPanel;
    public GameObject optionsPanel;
    public GameObject creditsPanel;

    public void Play()
    {
        Application.LoadLevel(1);
    }

    public void Options()
    {
        menuPanel.active = false;
        optionsPanel.active = true;
    }

    public void Credits()
    {
        menuPanel.active = false;
        creditsPanel.active = true; 
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        optionsPanel.active = false;
        creditsPanel.active = false;
        menuPanel.active = true;
    }
}
