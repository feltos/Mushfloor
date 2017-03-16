﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RafaleEnemy : AllEnemiesManager
{
    [SerializeField]
    float HP;
    [SerializeField]
    GameObject Target;
    [SerializeField]
    Rigidbody2D rb2dRM;
    private Vector2 Movement;
    [SerializeField]
    Vector2 Speed;
    Vector2 Direction;
    bool IsEnemy = true;
    [SerializeField]
    Transform RafalePrefab;
    float BulletShoot = 0.2f;
    float BulletCooldown = 0.2f;
    float Rafale = 3f;
    float RafaleCooldown = 3f;
    float BulletLeft = 12f;
    bool StopToShoot;
    

    void Awake()
    {
        Target = GameObject.Find("Player");
    }

    void Start ()
    {
        RafaleCooldown = 0f;
        BulletLeft = 0f;
        StopToShoot = true;
        OriginPosition = transform.position;
        
	}
	
	
	void Update ()
    {
        BulletShoot += Time.deltaTime;

        Direction = (Target.transform.position - transform.position).normalized;
        Movement = new Vector2(
            Speed.x * Direction.x,
            Speed.y * Direction.y);
        //////////FIRE//////////////
        fire();
        reload();
    }

    void FixedUpdate()
    {
        rb2dRM.velocity = Movement;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        BulletBasic shot = collision.gameObject.GetComponent<BulletBasic>();
        
        {
            if (shot.isEnemyShot != IsEnemy)
            {
                HP -= shot.damage;
                Destroy(shot.gameObject);
            }

            if (HP <= 0)
            {
                room.RemoveEnemy(gameObject);
                Destroy(gameObject);
            }       
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("AOE"))
        {
            HP -= 1;
        }
    }

    void fire()
    {
        if ((BulletShoot >= BulletCooldown) && !StopToShoot)
        {
            var RafaleShot = Instantiate(RafalePrefab, transform.position, transform.rotation) as Transform;
            RafaleShot.position = transform.position;
            BulletBasic Rafale = RafaleShot.gameObject.GetComponent<BulletBasic>();


            Rafale.isEnemyShot = true;
            Rafale.Direction = Direction;
            BulletShoot = 0f;
            BulletLeft -= 1f;
           
        }
       
    }

    void reload()
    {
        if(BulletLeft <= 0f)
        {
            StopToShoot = true;
            RafaleCooldown += Time.deltaTime;
            
        }
        if((RafaleCooldown >= Rafale) && (BulletLeft <= 0) && StopToShoot)
        {
            BulletLeft = 12f;
            RafaleCooldown = 0f;
            StopToShoot = false;
            
        }
    }



}
