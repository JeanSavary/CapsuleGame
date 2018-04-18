using UnityEngine;
using System.Collections;

public class Caster : LivingEntity
{

    public Player player;
    public Bullet bullet;
    public int damage;
 
   

    public Transform Target;
    
    public Fireball fireBall;

    public float MaximumLookDistance = 15;
    public float MaximumAttackDistance = 10;
    public float FollowSpeed = 5;
    public float MinimumDistanceFromPlayer = 2;
    public float RotationDamping = 6;
    public float Damping = 6;
    public float MoveSpeed = 5;
    


    protected override void Start()
    {
        base.Start();
        this.tag = "caster";
    }

    void Update()
    {
        var distance = Vector3.Distance(Target.position, transform.position);
        if (distance <= MaximumLookDistance)
        {
            LookAtTarget();

            if (distance <= MaximumAttackDistance )
            {
                
                AttackAndFollowTarget(distance);
            }
                
        }
        /*
        if (vitality == 0)
        {
            Destroy(this.gameObject);
        }
        */
    }

    void LookAtTarget()
    {
        
        var dir = Target.position - transform.position;
        dir.y = 0;
        var rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
    }
   
    void AttackAndFollowTarget(float distance)
    {
        if (distance > MinimumDistanceFromPlayer)
            transform.Translate((Target.position - transform.position).normalized * MoveSpeed * Time.deltaTime);

        Fireball newFireball = Instantiate (fireBall, transform.position +(Target.position - transform.position).normalized, Quaternion.LookRotation(Target.position - transform.position)) as Fireball;
    }

    public void OnCollisionEnter(Collision col)
    {
        

        if (col.gameObject.name == "Bullet(Clone)")
        {
            this.health -= bullet.damage;
        }
    }
}