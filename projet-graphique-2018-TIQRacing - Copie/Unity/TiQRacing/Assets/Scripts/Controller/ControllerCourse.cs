using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ControllerCourse : NetworkBehaviour {

    public static ControllerCourse instance;
	
	public static int number_players = 0;
    public static int number_player_finished = 0;

	public static int[] positionCheckpoint;

	private static float startTime;
	private static string minutes;
	private static string seconds;

	private bool stopTimer = false;

    private static GameObject race1;
    private static GameObject race2;
    private static GameObject race3;

	private int PlayerFinished = 0;
	private static string[] nameClassement;

    private void Awake()
    {
        instance = this;

		positionCheckpoint = new int[30];
		nameClassement = new string[30];

        race1 = GameObject.Find("Race1");
        race2 = GameObject.Find("Race2");
        race3 = GameObject.Find("Race3");

        race1.SetActive(true);
        race2.SetActive(false);
        race3.SetActive(false);
    }

    private void Start()
	{
		startTime = Time.time;

		EventsManager.AddListener("Player1Finished", Player1Finished);
		EventsManager.AddListener("Player2Finished", Player2Finished);
		EventsManager.AddListener("Player3Finished", Player3Finished);
		EventsManager.AddListener("Player4Finished", Player4Finished);
    }

	private void Update ()
	{
		if (stopTimer)
			return;

		float t = Time.time - startTime;

		minutes = ((int)t / 60).ToString();
		seconds = (t % 60).ToString("f2");


	}

    public void LoadClassementScene()
	{
		// Fin de course
		SceneManager.LoadScene("Classement");
	}

    [Command]
    public void CmdDestroyItem(GameObject item)
    {
        UnityEngine.GameObject.Destroy(item);
        Debug.Log("Item Destroyed");
        EventsManager.TriggerListener("ItemGet");

       
        
    }

    

    public static void OnPlayerFinish()
    {
        Debug.Log("controlleur finish");

        EventsManager.TriggerListener("PlayerFinished");
    }

    public static void ChangePlayerLap()
    {
        Debug.Log("new lap");

        EventsManager.TriggerListener("LapStarted");
    }
	
	public static void OnRaceFinish()
    {
        SceneManager.LoadScene("Classement");
    }

    public static int getNumberPlayers()
    {
        return number_players;
    }

    public static void AddNumberPlayer()
    {
        number_players++;
        Debug.Log("nombre de joueurs : " + number_players);
    }

    public static int getNumberPlayerFinished()
    {
        return number_player_finished;
    }

    public static void AddNumberPlayerFinished()
    {
        number_player_finished++;
        Debug.Log("nombre de joueurs : " + number_player_finished);
    }

	public static void PlayerIsFirst()
	{
		EventsManager.TriggerListener("PlayerIsFirst");
	}

	public static void PlayerIsSecond()
	{
		EventsManager.TriggerListener("PlayerIsSecond");
	}
	
	public static void PlayerIsThird()
	{
		EventsManager.TriggerListener("PlayerIsThird");
	}

	public static void PlayerIsFourth()
	{
		EventsManager.TriggerListener("PlayerIsFourth");
	}

	public static void AddPositionCheckpoint(int checkpoint)
	{
		positionCheckpoint[checkpoint]++;
	}

	public static void RestartCheckpoint(int checkpoint)
	{
		positionCheckpoint[checkpoint] = 0;
	}

	public static int getPositionCheckpoint(int checkpoint)
	{
		return positionCheckpoint[checkpoint];
	}

	public static string getMinutes()
	{
		return minutes;
	}

	public static string getSeconds()
	{
		return seconds;
	}

	public void StopTimer()
	{
		stopTimer = true;
	}

    public static int getActiveRace()
    {
        if (race1.activeInHierarchy)
            return 1;
        else if (race2.activeInHierarchy)
            return 2;
        else if (race3.activeInHierarchy)
            return 3;
        return 0;
    }

	private void Player1Finished()
	{
		

		if (PlayerFinished == 0)
			nameClassement[0] = "Joueur 1";
		else if (PlayerFinished == 1)
			nameClassement[1] = "joueur 1";
		else if (PlayerFinished == 2)
			nameClassement[2] = "joueur 1";
		else if (PlayerFinished == 3)
			nameClassement[3] = "joueur 1";

		Debug.Log ("Player1Finished() " + nameClassement[0]);

		PlayerFinished++;
	}

	private void Player2Finished()
	{
		if (PlayerFinished == 0)
			nameClassement[0] = "Joueur 2";
		else if (PlayerFinished == 1)
			nameClassement[1] = "joueur 2";
		else if (PlayerFinished == 2)
			nameClassement[2] = "joueur 2";
		else if (PlayerFinished == 3)
			nameClassement[3] = "joueur 2";

		Debug.Log ("Player2Finished() " + nameClassement[0]);

		PlayerFinished++;
	}

	private void Player3Finished()
	{
		if (PlayerFinished == 0)
			nameClassement[0] = "Joueur 3";
		else if (PlayerFinished == 1)
			nameClassement[1] = "joueur 3";
		else if (PlayerFinished == 2)
			nameClassement[2] = "joueur 3";
		else if (PlayerFinished == 3)
			nameClassement[3] = "joueur 3";

		Debug.Log ("Player3Finished() " + nameClassement[0]);

		PlayerFinished++;
	}

	private void Player4Finished()
	{
		if (PlayerFinished == 0)
			nameClassement[0] = "Joueur 4";
		else if (PlayerFinished == 1)
			nameClassement[1] = "joueur 4";
		else if (PlayerFinished == 2)
			nameClassement[2] = "joueur 4";
		else if (PlayerFinished == 3)
			nameClassement[3] = "joueur 4";

		Debug.Log ("Player4Finished() " + nameClassement[0]);

		PlayerFinished++;
	}

	public static string[] getNamesClassement()
	{
		return nameClassement;
	}

}