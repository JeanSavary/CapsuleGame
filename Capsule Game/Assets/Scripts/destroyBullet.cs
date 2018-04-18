using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBullet : MonoBehaviour {


    
    private void OnCollisionEnter(Collision col)
    {
        //print(col.gameObject.name);
        if (col.gameObject.name != "Player")
        {
            Destroy(this.gameObject);
        }
            
    }
 
}
