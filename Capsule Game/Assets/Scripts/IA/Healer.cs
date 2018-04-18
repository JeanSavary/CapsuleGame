using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class Healer : LivingEntity
{
    // Attributs
    public Player player;

    public Bullet bullet;
    public int heal;
    public float firerate;
    public int destinationDistance;
    private bool isHealingExecuting = false;



    UnityEngine.AI.NavMeshAgent pathfinder;
    Transform target;

    // Use this for initialization
    protected override void Start()
    {
        base.Start ();
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdatePath());
        
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (vitality <= 0)
        {
            Destroy(this.gameObject);
        }
        */
        //print(isHealingExecuting);
        if (isHealingExecuting == false)
        {
            isHealingExecuting = true;
            StartCoroutine(HealEm());
            
        }
    }

    IEnumerator UpdatePath()
    {
        
        float refreshRate = .25f;

        while (target != null && destinationReached() == false)
        {

            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
    }

    IEnumerator HealEm()
    {
        
        
        //Follower enemyToHeal = GameObject.FindGameObjectWithTag("Follower");
        GameObject[] healList;
        healList = GameObject.FindGameObjectsWithTag("follower");
        print(healList);
        while (healList != null)
        {
            //print("1");
            foreach (GameObject enemy in healList)
            {

                Follower follower = enemy.GetComponent<Follower>() as Follower;
                //print(follower);
                if (follower.health <= 100 - heal)
                {
                    //print("heal");
                    follower.health += heal;
                }
            }
            yield return new WaitForSeconds(firerate);
            isHealingExecuting = false;

        }
    }

    public bool destinationReached()
    {
        Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
        Vector3 myPosition = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        if (Vector3.Distance(targetPosition, myPosition) <= destinationDistance)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Bullet(Clone)")
        {
            health -= bullet.damage;
        }
    }
}
