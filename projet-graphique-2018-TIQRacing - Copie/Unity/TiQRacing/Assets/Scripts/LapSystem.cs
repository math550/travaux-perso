using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LapSystem : NetworkBehaviour
{
    public int number_checkpoint;
    public int current_checkpoint;
    public int number_laps;
    public int current_lap;

	public PlayerObject player;


	// Use this for initialization
	void Start ()
    {
        number_checkpoint = GameObject.Find ("Checkpoint").transform.childCount;
        current_checkpoint = 1;
        number_laps = 2;
        current_lap = 1;



    }

    private void OnTriggerEnter2D(Collider2D check_col)
    {
        Checkpoint checkpoint = check_col.GetComponent<Checkpoint>();

        if(checkpoint != null)
        {
            Debug.Log("We just hit a checkpoint");
          
            if(checkpoint.idCheckpoint == current_checkpoint)
            {

				/*if (positionCheckpoint [checkpoint.idCheckpoint] == 0) 
				{
					ControllerCourse.ChangePlayerPosition();

					positionCheckpoint [checkpoint.idCheckpoint]++;
				}*/

				switch (ControllerCourse.getPositionCheckpoint(checkpoint.idCheckpoint))
				{
				case 0:
					Debug.Log ("Case 0");
					if (hasAuthority)
					{
						ControllerCourse.PlayerIsFirst ();
					}

					ControllerCourse.AddPositionCheckpoint (checkpoint.idCheckpoint);
					break;
				case 1:
					Debug.Log ("Case 1");
					if (hasAuthority)
					{
						ControllerCourse.PlayerIsSecond ();
					}

					ControllerCourse.AddPositionCheckpoint (checkpoint.idCheckpoint);
					break;
				case 2:
					Debug.Log ("Case 2");
					if (hasAuthority)
					{
						ControllerCourse.PlayerIsThird ();
					}

					ControllerCourse.AddPositionCheckpoint (checkpoint.idCheckpoint);
					break;
				case 3:
					Debug.Log ("Case 3");
					if (hasAuthority)
					{
						ControllerCourse.PlayerIsFourth ();
					}

					ControllerCourse.RestartCheckpoint (checkpoint.idCheckpoint);
					break;
				default:
					Debug.Log ("Ca chie");
					break;
				}

                if (checkpoint.isFinishLine)
                {
                    current_lap++;
                    current_checkpoint = 1;

                    if (current_lap > number_laps)
                    {
                        if (hasAuthority)
                        {
                            var camFollow = Camera.main.GetComponent<CameraFollow>();
                            camFollow.setTarget(this.gameObject.transform);
                            camFollow.UnzoomCam();

							Debug.Log ("PLAYER FINISHED");

                            ControllerCourse.OnPlayerFinish();
							ControllerCourse.instance.StopTimer();

							EventsManager.TriggerListener("PlayerNameFinished");
                        }



						ControllerCourse.AddNumberPlayerFinished();

                        

                        Debug.Log("NumberPlayers " + ControllerCourse.getNumberPlayers());

                        if (ControllerCourse.getNumberPlayers() == ControllerCourse.getNumberPlayerFinished())
                        {
                            RpcEndRace();
                        }
                    }
                }
                else
                {
                    current_checkpoint++;
                }
                
            }
            
        }
    }
	
	[ClientRpc]
    public void RpcEndRace()
    {
        EventsManager.TriggerListener("RaceFinished");
    }
}
