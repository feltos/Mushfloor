using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleMonster : AllEnemiesManager
{
    [SerializeField]
    float HP;
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
    bool IsTurnedRight = false;

    void Awake()
    {
        Target = GameObject.Find("Player");
    }

    protected override void Start()
    {
        ShootCooldown = 0f;
        base.Start(); 
	}
	
	
	void Update ()
    {
        ShootCooldown += Time.deltaTime;

        Direction = (Target.transform.position - transform.position).normalized;
        Movement = new Vector2(
            Speed.x * Direction.x,
            Speed.y * Direction.y);
        if (rb2dLM.velocity.x > 0 && !IsTurnedRight)
        {
            Flip();
        }
        if (rb2dLM.velocity.x < 0 && IsTurnedRight)
        {
            Flip();
        }
        /////////////FIRE//////////////
        if (ShootCooldown >= BulletShoot)
        {
            SoundManager.Instance.BasicFire();
            fire();
        }       
        //////////////////////////////
	}

    void FixedUpdate()
    {
        rb2dLM.velocity = Movement;
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
           

    }

    void fire()
    {
        
        
        var shotTransform = Instantiate(BulletPrefab, transform.position, transform.rotation) as Transform;
        shotTransform.position = transform.position;
        BulletBasic shot = shotTransform.gameObject.GetComponent<BulletBasic>();
            

        shot.isEnemyShot = true;
        shot.Direction = Direction;
        ShootCooldown = 0f;       
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        IsTurnedRight = !IsTurnedRight;
    }

}
