using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonScript : MonoBehaviour {

    public ScoreScript scorescript;
    public int UpgradeCost;
    public Bullet bullet;
    public int damageUpgrade;

    public void UPGRADE()
    {
        if (scorescript.Score >= UpgradeCost)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                scorescript.Score -= UpgradeCost;
                bullet.damage += damageUpgrade;
            }
               
            
        }
        
    }

}
