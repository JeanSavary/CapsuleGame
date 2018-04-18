using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject MenuObject;
    private bool onPause = false;
    private bool muted = false;
    //Camera camera;
    
    private void Start()
    {

        Cursor.visible = true;
        AudioListener.pause = false;
        //camera = GetComponent<Camera>();
    }
    
	
	
	void Update () {
		if (onPause == true)
        {
            
            MenuObject.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        else
        {
            
            MenuObject.SetActive(false);
            Cursor.visible = false;
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onPause = !onPause;
        }
	}
    public void RESUME()
    {
        onPause = !onPause;
    }

    public void MUSIC_MENU()
    {
        if (muted == false)
        {
            AudioListener.pause = true;
            muted = true;
        }
        else
        {
            AudioListener.pause = false;
            muted = false;
        }
    }

    public void MAIN_MENU()
    {
        Application.LoadLevel("MenuPrincipal");
    }
}
