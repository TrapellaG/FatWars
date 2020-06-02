using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatacterManager : MonoBehaviour
{
    public ArrayList players = new ArrayList();

    public Text Textplayer1; 
    public Text Textplayer2; 
    public Text Textplayer3; 
    public Text Textplayer4;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public int numPlayers = 0;

    playerManager playermanager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.Find("MainCamera");
        playermanager = camera.GetComponent<playerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("SubmitP1"))
        {
            Textplayer1.text = "ok";
            players.Add(player1);
            numPlayers++;
        }
        else if (Input.GetButtonDown("SubmitP2"))
        {
            Textplayer2.text = "ok";
            players.Add(player2);
            numPlayers++;
        }
        else if (Input.GetButtonDown("SubmitP3"))
        {
            Textplayer3.text = "ok";
            players.Add(player3);
            numPlayers++;
        }
        else if (Input.GetButtonDown("SubmitP4"))
        {
            Textplayer4.text = "ok";
            players.Add(player4);
            numPlayers++;
        }
        else if(Input.GetButtonDown("Submit"))
        {
            playermanager.SelectCharactersDone();
        }
    }
}
