using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewClassement : MonoBehaviour {
	
	[SerializeField]
	private Text txtJoueur1;
	[SerializeField]
	private Text txtJoueur2;
	[SerializeField]
	private Text txtJoueur3;
	[SerializeField]
	private Text txtJoueur4;
	[SerializeField]
	private Text txtTemps1;
	[SerializeField]
	private Text txtTemps2;
	[SerializeField]
	private Text txtTemps3;
	[SerializeField]
	private Text txtTemps4;
	[SerializeField]
	private Text txtTour1;
	[SerializeField]
	private Text txtTour2;
	[SerializeField]
	private Text txtTour3;
	[SerializeField]
	private Text txtTour4;


	private string[] nameClassement;

	// Use this for initialization
	void Start ()
    {

		nameClassement = ControllerCourse.getNamesClassement();

		DoClassement();



        // La vue écoute les différents événements qui ont un impacte sur cette dernière et agit en conséquence
        EventsManager.AddListener("ButtonReturnClicked", OnButtonReturnClicked);
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    void OnDisable()
    {

    }


    public void OnButtonReturnClicked()
    {
        Debug.Log("OnButtonReturnClicked");


        // Changement de scene, retour au menu pricipal
        ControllerClassement.LoadMainMenuScene();

    }


	public void DoClassement()
	{
		Debug.Log("RpcDoClassement()");

		txtJoueur1.text = nameClassement[0];
		txtJoueur2.text = nameClassement[1];
		txtJoueur3.text = nameClassement[2];
		txtJoueur4.text = nameClassement[3];

	}


}
