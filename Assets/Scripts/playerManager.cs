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
    public AudioSource music;
    public Text winner;

    public void PlayAgain()
    {
        panel.active = false;
        Application.LoadLevel(Application.loadedLevel);
    }

    // Update is called once per frame
    void Update()
    {
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
            music.gameObject.active = false;
        }
    }
}
