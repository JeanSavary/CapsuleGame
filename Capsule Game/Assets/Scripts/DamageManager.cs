using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageManager : MonoBehaviour {

    // Use this for initialization

    
    
    public Renderer rend;
    public GUIText myText;

    void Start () {
        rend = GetComponent<Renderer>();

    }
	public int takeDamage(int vitality, int amount)
    {
        vitality -= amount;
        //HealthSlider.value = vitality;
        /*
        if (vitality <= 80 && vitality > 40)
        {
            rend.material.color = Color.green;
        }
        else if (vitality <= 40 && vitality > 20)
        {
            rend.material.color = Color.blue;
        }
        else if (vitality <= 20 && vitality > 0)
        {
            rend.material.color = Color.red;
        }
        */
        if (vitality == 0)
        {
            //Destroy(this.gameObject);
            myText.material.color = Color.magenta;

            myText.text = "I N S U P P O R T A B L E";
        }
        return vitality;
    }



	// Update is called once per frame
	void Update () {
     
    }
}
