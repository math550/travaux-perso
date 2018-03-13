using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewMainMenu : MonoBehaviour {


    [SerializeField]
    private RectTransform Panel_Menu;

    [SerializeField]
    private RectTransform Panel_Choisir_Course;

    [SerializeField]
    private RectTransform Panel_Option;


    public void Start()
    {
        Panel_Menu.gameObject.SetActive(true);

        Panel_Choisir_Course.gameObject.SetActive(false);

        Panel_Option.gameObject.SetActive(false);
    }


    public void OnButtonPlay()
    {
        Panel_Menu.gameObject.SetActive(false);

        Panel_Choisir_Course.gameObject.SetActive(true);
    }

    public void OnButtonOptions()
    {
        Panel_Menu.gameObject.SetActive(false);

        Panel_Option.gameObject.SetActive(true);
    }

    public void OnButtonExit()
    {
        // Quitter l'application
        ControllerMainmenu.ExitGame();
    }

    public void OnButtonReturn()
    {
        Panel_Menu.gameObject.SetActive(true);

        Panel_Choisir_Course.gameObject.SetActive(false);

        Panel_Option.gameObject.SetActive(false);
    }

    public void OnButtonGo()
    {
        ControllerMainmenu.LoadCourseScene();
    }

    private void SelectMap()
    {
        Debug.Log("Player selected map");
    }

    private void SelectCar()
    {
        Debug.Log("Player selected car");
    }

    private void AllSelected()
    {
        Debug.Log("All player has selected map and cars");

        // Change scene
        ControllerMainmenu.LoadCourseScene();
    }
}
