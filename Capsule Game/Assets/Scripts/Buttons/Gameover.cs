using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    public void Start()
    {
        Cursor.visible = true;

    }
    public void RETOURMENUPRINCIPAL()
    {
        Application.LoadLevel("MenuPrincipal");
    }
}
