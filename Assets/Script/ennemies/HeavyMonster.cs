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

    protected override void Start ()
    {
        ShootCooldown = 0f;
        base.Start();
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
        BulletBasic shot = collision.gameObject.GetComponent<BulletBasic>();
        if (shot != null)
        {
            if (shot.isEnemyShot != IsEnemy)
            {
                HP -= shot.damage;
                Destroy(shot.gameObject);
            }

            if (HP <= 0)
            {
                SoundManager.Instance.EnnemyHurt();
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
        

        if (ShootCooldown >= BulletShoot)
        {
            SoundManager.Instance.BigBulletFire();
            var HeavyBulletShot = Instantiate(HeavyBulletPrefab, transform.position, transform.rotation);
            HeavyBulletShot.transform.position = transform.position;
            BulletBasic HeavyBullet = HeavyBulletShot.gameObject.GetComponent<BulletBasic>();

            HeavyBullet.isEnemyShot = true;
            HeavyBullet.Direction = Direction;
           
            ShootCooldown = 0f;
        }

    }


}
