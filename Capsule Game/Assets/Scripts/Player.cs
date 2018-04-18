using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]

public class Player : LivingEntity {


    LivingEntity player;

    //public Slider HealthSlider;

    public float moveSpeed = 5;

    Camera viewCamera;
    public Fireball fireball;
    public Follower follower;
    public Boss boss;
    PlayerController controller;
    GunController gunController;
    public Slider HealthSlider;


    protected override void Start() {
        player = this;
        base.Start();
        gunController = GetComponent<GunController>();
        controller = GetComponent<PlayerController>();
        viewCamera = Camera.main;

    }

    void Update() {
        //print(health);
        HealthSlider.value = this.health;
        // Movement Input

        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        // Look Input
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance)) {

            Vector3 point = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);

        }
        // Weapon Input

        if (Input.GetMouseButton(0)) {

            gunController.Shoot();

        }

        if (this.health <= 0)
        {
            Application.LoadLevel("GameOver");
        }

    }

    void OnCollisionEnter(Collision col)
    {        
        if (col.gameObject.name == "Fireball(Clone)")
        {
            print("FIRE");
            health -= fireball.damage;
        }

        else if (col.gameObject.name == "Follower(Clone)") {
            health -= follower.damage;
        }

        else if (col.gameObject.name == "Boss(Clone)")
        {
            health -= boss.damage;
        }
    }
}