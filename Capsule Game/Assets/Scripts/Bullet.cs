using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	Vector3 bulletStartPosition;
	public LayerMask collisionMask;
	float speed = 10;
    public float damage = 10;
	float distanceBeforeVanish = 20f;

	public void SetSpeed (float newSpeed) {

		speed = newSpeed;
	
	}
	void Start () {

		bulletStartPosition = transform.position;

	}
	void Update () {
		
		float moveDistance = speed * Time.deltaTime;
		CheckCollisions (moveDistance);
		transform.Translate (Vector3.forward * Time.deltaTime * speed);

		if (Mathf.Abs(Vector3.Distance(transform.position, bulletStartPosition)) > distanceBeforeVanish) {

			GameObject.Destroy (gameObject);
		}
			
	}

	void CheckCollisions (float moveDistance) {

		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide)) {

			OnHitObject (hit);

		}
	}

	void OnHitObject(RaycastHit hit) {

        //print (hit.collider.gameObject.name);
        IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeHit(damage, hit);
        }
        GameObject.Destroy (gameObject);

	}
}


