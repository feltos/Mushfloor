using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyMonster : AllEnemiesManager
{
    [SerializeField]
    float HP;
    [SerializeField]
    GameObject Target;
    [SerializeField]
    Rigidbody2D rb2dHM;
    private Vector2 Movement;
    [SerializeField]
    Rigidbody2D HeavyBullet;
    [SerializeField]
    Vector2 Speed;
    [SerializeField]
    Vector2 Direction;
    bool IsEnemy = true;
    [SerializeField]
    Transform HeavyBulletPrefab;
    float ShootCooldown = 4f;
    float BulletShoot = 4f;
    

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
        /////////////////MOVE///////////////////
        Direction = (Target.transform.position - transform.position).normalized;
        Movement = new Vector2(
            Speed.x * Direction.x,
            Speed.y * Direction.y);
        /////////////FIRE//////////////
        fire();
     

    }

    void FixedUpdate()
    {
        rb2dHM.velocity = Movement;
      
    }

    void OnTriggerEnter2D(Collider2D collision)
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

        if (collision.gameObject.layer == LayerMask.NameToLayer("AOE"))
        {
            HP -= 1;
        }
    }


    void fire()
    {
        

        if (ShootCooldown >= BulletShoot)
        {
            var HeavyBulletShot = Instantiate(HeavyBulletPrefab, transform.position, transform.rotation);
            HeavyBulletShot.transform.position = transform.position;
            ShotBasic HeavyBullet = HeavyBulletShot.gameObject.GetComponent<ShotBasic>();

            HeavyBullet.isEnemyShot = true;
            HeavyBullet.Direction = Direction;
           
            ShootCooldown = 0f;
        }

    }


}
