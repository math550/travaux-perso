using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerMainmenu : MonoBehaviour {

	public static void LoadCourseScene()
    {
        SceneManager.LoadScene("Course");
    }

    public static void LoadMainMenuScene()
    {
        SceneManager.LoadScene("Retour");
    }

    public static void ExitGame()
    {
        Application.Quit();
    }
}
