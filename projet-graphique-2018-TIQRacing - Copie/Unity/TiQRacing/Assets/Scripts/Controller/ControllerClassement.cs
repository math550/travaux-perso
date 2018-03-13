using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public static class ControllerClassement {

     

    public static void LoadMainMenuScene()
    {
        // Exécution du traitement
        //NetworkManager.singleton.StopHost();
        SceneManager.LoadScene("Main menu");
        
        
    }

}
