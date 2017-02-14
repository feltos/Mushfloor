using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyMonster : MonoBehaviour
{
    [SerializeField]
    int HP;
    [SerializeField]
    GameObject Target;
    [SerializeField]
    Rigidbody2D rb2dHM;
    private Vector2 Movement;
    private Vector2 MovementOfShot;
    [SerializeField]
    Vector2 Speed;
    [SerializeField]
    Vector2 SpeedOfShot;
    Vector2 Direction;
    bool IsEnemy = true;
    Vector2 direction;
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
        ///////////SHOT DIRECTION////////////
         
        MovementOfShot = new Vector2(
            SpeedOfShot.x * Direction.x,
            SpeedOfShot.y * Direction.y);
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

    }


    void fire()
    {
        if (ShootCooldown >= BulletShoot)
        {
            var shotTransform = Instantiate(HeavyBulletPrefab, transform.position, transform.rotation) as Transform;
            shotTransform.position = transform.position;
           
          
            ShootCooldown = 0f;
        }

    }
}
