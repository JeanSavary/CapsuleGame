using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenuScript : MonoBehaviour
{

    

    public void LOAD_SCENE()
    {
        Application.LoadLevel("ShooterLouis");
    }

    public void QUIT_GAME()
    {
        Application.Quit();
    }

    public void INSTRUCTION()
    {
        Application.LoadLevel("Instructions");
    }

    public void CREDIT()
    {
        Application.LoadLevel("Credits");
    }
    


    
}