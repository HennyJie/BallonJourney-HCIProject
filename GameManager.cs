using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject floor;
    public GameObject top;
    public GameObject balloon;
    public Spawner spawner;
    public GameObject playerPrefab;
    private GameObject player;
    public bool over = false;



    void Awake()
    {
        floor = GameObject.Find("floor");
        top = GameObject.Find("top");
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
       
    }

    void ResetGame()
    {
        spawner.active = true;
    }

    public Text scoreText;
    public Text startText;
    private float timeElapsed = 0f;
    private float bestTime = 0f;

    string FormatTime(float value)
    {
        value = (int)value;
        return value.ToString();
    }

	// Use this for initialization
	void Start () {

        //  ResetGame();
        Time.timeScale = 0;
        timeElapsed = 0f;
        bestTime=PlayerPrefs.GetFloat("BestTime");
        startText.text = "Pull the ballon to start game！";

    }

    // Update is called once per frame
    void Update () {
        if (spawner.active == false && Time.timeScale == 0)
        {
            if (over == false)
            {
                if (Input.anyKeyDown)
                {
                    Time.timeScale = 1;
                    startText.text = "";
                    ResetGame();
                }
            }
            else if(over == true)
            {
                if (Input.anyKeyDown)
                {
                    //print("进入新场景");
                    Application.LoadLevel("startScene 1");
                }
            }
        }


        var fpos = floor.transform.position;
        fpos.x = Camera.main.transform.position.x;
        floor.transform.position = fpos;

        var tpos = top.transform.position;
        tpos.x = Camera.main.transform.position.x;
        top.transform.position = tpos;

        scoreText.text = "Score: " + FormatTime(timeElapsed) + "\nBest: " + FormatTime(bestTime);
        timeElapsed = timeElapsed + Time.deltaTime;

        if (spawner.active==false&& Time.timeScale != 0)
        {
            OnPlayerKilled();
        }
	}

    void OnPlayerKilled()
    {
        over = true;
        Time.timeScale = 0;
        spawner.active = false;
        if (timeElapsed > bestTime)
        {
            bestTime = timeElapsed;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            startText.text = "Congratulations!\n"+"Pull the balloon return the start page"+"\nYour score is "+ FormatTime(timeElapsed);
        }
        else
        {
            startText.text = "Come on!\n" + "Pull the balloon return the start page" + "\nYour score is " + FormatTime(timeElapsed);
        }

        //if (Input.anyKeyDown)
        //{
        //    print("进入新场景");
        //    Application.LoadLevel("StartScene");
        //}

    }
}
