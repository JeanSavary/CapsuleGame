using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public Transform muzzle;
	public float msBetweenShots = 50;
	public Bullet bullet;
	public float muzzleVelocity = 35;

	float nextShotTime;


	public void Shoot () {
		
		if (Time.time > nextShotTime) {

			nextShotTime = Time.time + msBetweenShots / 1000;
			Bullet newBullet = Instantiate (bullet, muzzle.position, muzzle.rotation) as Bullet;
			newBullet.SetSpeed (muzzleVelocity);

		}
	}
}
