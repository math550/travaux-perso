using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewCourse : MonoBehaviour
{
    [SerializeField]
    private Text txtPosition;
    [SerializeField]
    private Text txtLaps;
    [SerializeField]
    private Text textTimer;
	[SerializeField]
	private Text txtFinish;
	[SerializeField]
    private Image imageItem;

    int laps = 0;



    // Use this for initialization
    void Start ()
    {
		txtFinish.enabled = false;


        //Check event position
		EventsManager.AddListener("PlayerIsFirst", PlayerIsFirst);
		EventsManager.AddListener("PlayerIsSecond", PlayerIsSecond);
		EventsManager.AddListener("PlayerIsThird", PlayerIsThird);
		EventsManager.AddListener("PlayerIsFourth", PlayerIsFourth);
        //Check event item
        EventsManager.AddListener("ItemGet", OnItemGet);
        //EventsManager.TriggerListener("Item");
        EventsManager.AddListener("ItemUsed", OnItemUsed);
        //Check event timer
        EventsManager.AddListener("PlayerStarted", OnPlayerStart);
        EventsManager.AddListener("PlayerFinished", OnPlayerFinish);
        //Check event laps
        EventsManager.AddListener("LapStarted", OnNewLap);
		//Check event race
		EventsManager.AddListener("RaceFinished", OnRaceFinish);
    }

	private void Update()
	{
		UpdateTimer ();
	}



    private void OnDestroy()
    {
        //Check event position
		EventsManager.RemoveListener("PlayerIsFirst", PlayerIsFirst);
		EventsManager.RemoveListener("PlayerIsSecond", PlayerIsSecond);
        //Check event item
        EventsManager.RemoveListener("ItemGet", OnItemGet);
        EventsManager.RemoveListener("ItemUsed", OnItemUsed);
        //Check event timer
        EventsManager.RemoveListener("PlayerStarted", OnPlayerStart);
        EventsManager.RemoveListener("PlayerFinished", OnPlayerFinish);
        //Check event laps
        EventsManager.RemoveListener("LapStarted", OnNewLap);
		//Check event race
		EventsManager.AddListener("RaceFinished", OnRaceFinish);
    }

    private void OnPositionChanged()
    {
        Debug.Log("Player changed position");

        ChangePlayerPosition(txtPosition);
    }

    private void OnItemGet()
    {
        Debug.Log("Player got new item");

        ChangePlayerItemSlotGet(imageItem);
    }

    private void OnItemUsed()
    {
        Debug.Log("Player used item");

        ChangePlayerItemSlotUsed(imageItem);
    }

    private void OnNewLap()
    {
        Debug.Log("Player did a lap");
        ChangePlayerLap(txtLaps);
    }

    private void OnPlayerStart()
    {
        Debug.Log("Player started the race");
        // Start the timer

    }

    private void OnPlayerFinish()
    {
        Debug.Log("Player finished the race");

        //Stop the timer

		//Show finish text
		txtFinish.enabled = true;
    }
	private void OnRaceFinish()
	{
		Debug.Log("All Players finished the race");

		//Change Scene
		ControllerCourse.OnRaceFinish();
	}

    private void ChangePlayerPosition(Text txtPosition)
    {
        //txtPosition.text = "Position : 1 / 2";
        
    }

	private void PlayerIsFirst()
	{
		txtPosition.text = "1 / 4";
	}

	private void PlayerIsSecond()
	{
		txtPosition.text = "2 / 4";
	}
	
	private void PlayerIsThird()
	{
		txtPosition.text = "3 / 4";
	}

	private void PlayerIsFourth()
	{
		txtPosition.text = "4 / 4";
	}

    private void ChangePlayerLap(Text txtLaps)
    {
        if(laps >= 2)
        {
            laps = 2;
        }
        else
        {
            txtLaps.text = laps + " / 2";
            laps++;
            txtLaps.text = laps + " / 2";
        }
        
    }

	private void ChangePlayerItemSlotGet(Image imageItem)
	{
		Debug.Log("Item get");
		imageItem.color = Color.red;
	}

	private void ChangePlayerItemSlotUsed(Image imageItem)
	{
		Debug.Log("Item get");
		imageItem.color = Color.white;
	}

	private void UpdateTimer()
	{
		string minutes = ControllerCourse.getMinutes ();
		string seconds = ControllerCourse.getSeconds ();

		textTimer.text = minutes + ":" + seconds;
	}
}
