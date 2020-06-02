using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public int players = 4;

    bool ok1 = true;
    bool ok2 = true;
    bool ok3 = true;
    bool ok4 = true;

    public GameObject panel;
    public GameObject playersPanel;
    public GameObject panleBurger;
    public GameObject pausePanel;
    public AudioSource music;
    public Text winner;
    public Button exitToMenuF;
    public Button exitToMenuP;
    public Button resume;

    public ChatacterManager playermanager;

    public void Start()
    {
        GameObject camera = GameObject.Find("MainCamera");
        playermanager = camera.GetComponent<ChatacterManager>();

        Time.timeScale = 0;
        panleBurger.active = false;
        music.Pause();
        panel.active = false;
    }

    public void SelectCharactersDone()
    {
        if (playermanager.numPlayers < 4)
        {
            Destroy(player4);

            if (playermanager.numPlayers < 3)
            {
                Destroy(player3);

                if (playermanager.numPlayers < 2)
                {
                    Destroy(player2);
                }
            }
        }

        Time.timeScale = 1f;
        panleBurger.active = true;
        playersPanel.active = false;
        music.Play();
    }

    public void PlayAgain()
    {
        panel.active = false;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void ExitToMenu()
    {
        Application.LoadLevel(0);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pausePanel.active = false;
        music.Play();
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.active = true;
        music.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("pause"))
        {
            PauseGame();
        }

        if(player1 == null && ok1 == true)
        {
            ok1 = false;
            Debug.Log("xao player1");
            players--;
        }
        if (player2 == null && ok2 == true)
        {
            ok2 = false;
            players--;
        }
        if (player3 == null && ok3 == true)
        {
            ok3 = false;
            players--;
        }
        if (player4 == null && ok4 == true)
        {
            ok4 = false;
            players--;
        }

        if(players == 1)
        {
            if (player1 != null)
            {
                winner.text = "player 1 wins";
            }
            if (player2 != null)
            {
                winner.text = "player 2 wins";
            }
            if (player3 != null)
            {
                winner.text = "player 3 wins";
            }
            if (player4 != null)
            {
                winner.text = "player 4 wins";
            }

            panel.active = true;
            panleBurger.active = false;
            music.gameObject.active = false;
        }
    }
}
