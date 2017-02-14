﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleMonster : MonoBehaviour
{
    [SerializeField]
    int HP;
    [SerializeField]
    GameObject Target;
    [SerializeField]
    Rigidbody2D rb2dLM;
    private Vector2 Movement;
    [SerializeField]
    Vector2 Speed;
    Vector2 Direction;
    bool IsEnemy = true;
    [SerializeField]
    Transform BulletPrefab;
    float ShootCooldown = 1.5f;
    float BulletShoot = 1.5f;

    void Awake()
    {
        Target = GameObject.Find("Player");
    }

    void Start ()
    {
        ShootCooldown = 0f;
	}
	
	
	void Update ()
    {
        ShootCooldown += Time.deltaTime;

        Direction = (Target.transform.position - transform.position).normalized;
        Movement = new Vector2(
            Speed.x * Direction.x,
            Speed.y * Direction.y);
        /////////////FIRE//////////////
        fire();
        //////////////////////////////
	}

    void FixedUpdate()
    {
        rb2dLM.velocity = Movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         
        ShotBasic shot = collision.gameObject.GetComponent<ShotBasic>();
        if (shot != null)
        {
            if (shot.isEnemyShot != IsEnemy)
            {
                HP -= shot.damage;
                Destroy(shot.gameObject);
            }
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }
    
    }

    void fire()
    {
        if(ShootCooldown >= BulletShoot)
        {
            var shotTransform = Instantiate(BulletPrefab, transform.position, transform.rotation) as Transform;
            shotTransform.position = transform.position;
            ShotBasic shot = shotTransform.gameObject.GetComponent<ShotBasic>();
            

            shot.isEnemyShot = true;
            shot.Direction = Direction;
            ShootCooldown = 0f;
        }
        
    }


   
}