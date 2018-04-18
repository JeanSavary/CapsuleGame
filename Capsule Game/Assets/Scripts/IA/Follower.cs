using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class Follower : LivingEntity
{
    // Attributs
    public Player player;

    public Bullet bullet;
    public int damage;
    public int firerate;
   


    UnityEngine.AI.NavMeshAgent pathfinder;
    Transform target;

    // Use this for initialization
    protected override void Start()
    {
        this.tag = "follower";
        base.Start();
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        this.tag = "follower";
        StartCoroutine(UpdatePath());
    }

    // Update is called once per frame
    void Update()
    {
       /* if (vitality <= 0)
        {
            Destroy(this.gameObject);
        }
        */
       
    }

    IEnumerator UpdatePath()
    {

        float refreshRate = .25f;

        while (target != null)
        {

            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        

        if (col.gameObject.name == "Bullet(Clone)")
        {
            this.health -= bullet.damage;
        }
    }


}
