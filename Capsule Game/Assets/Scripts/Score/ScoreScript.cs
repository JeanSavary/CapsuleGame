using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public Text ScoreText;
    public Button UpgradeWeapon;
    
    public int Score;
    public int CostUpgrade;
	

	void Start () {
        
        UpdateScore();
        UpgradeWeapon.interactable = false;
        
	}
	
	
	void Update () {
        UpdateScore();
		if (Score >= CostUpgrade)
        {
            UpgradeWeapon.interactable = true;
        }
        else
        {
            UpgradeWeapon.interactable = false;
        }
	}

    public void AddScore (int newScoreValue)
    {
        Score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Score: " + Score;
    }

}
