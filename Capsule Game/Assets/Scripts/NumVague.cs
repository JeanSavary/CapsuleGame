using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumVague : MonoBehaviour {

    public Text numVague;
    public Spawner spawner;
	
	
	// Update is called once per frame
	void Update () {
        numVague.text = "Vague : " + spawner.currentWaveNumber +" sur " + spawner.numberOfWaves;
        
        if (spawner.currentWaveNumber > spawner.numberOfWaves)
            Application.LoadLevel("Bravo");
    }
}
