using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour
{

    Vector3 fireballStartPosition;
    public LayerMask collisionMask;
    float speed = 10;
    public float damage = 10;
    Player player;
    float distanceBeforeVanish = 20f;

    public void SetSpeed(float newSpeed)
    {

        speed = newSpeed;

    }
    void Start()
    {

        fireballStartPosition = transform.position;

    }
    void Update()
    {
        /*
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        */
        if (Mathf.Abs(Vector3.Distance(transform.position, fireballStartPosition)) > distanceBeforeVanish)
        {

            GameObject.Destroy(gameObject);
        }

        transform.Translate(transform.forward);
    }

    void CheckCollisions(float moveDistance)
    {

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide))
        {

            OnHitObject(hit);

        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            player.health -= damage;

        }
    }
    */
    void OnHitObject(RaycastHit hit)
    {
        GameObject.Destroy(gameObject);
    }
}


