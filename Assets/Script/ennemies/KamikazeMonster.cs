using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeMonster : AllEnemiesManager
{

    [SerializeField]
    float HP;
    [SerializeField]
    Rigidbody2D rb2dKM;
    Vector2 Direction;
    Vector2 Movement;
    [SerializeField]
    Vector2 Speed;
    [SerializeField]
    GameObject Target;
    bool IsEnemy = true;
    [SerializeField]GameObject PoisonCircle;
    

    void Awake()
    {
        Target = GameObject.Find("Player");
    }

    void Start ()
    {
        OriginPosition = transform.position;
	}
	
	
	void Update ()
    {
        Direction = (Target.transform.position - transform.position).normalized;
        Movement = new Vector2(
            Speed.x * Direction.x,
            Speed.y * Direction.y);
	}

    void FixedUpdate()
    {
        rb2dKM.velocity = Movement;
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
                Instantiate(PoisonCircle, transform.position, transform.rotation);
                SoundManager.Instance.EnnemyHurt();
                room.RemoveEnemy(gameObject);
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("AOE"))
        {
            HP -= 1;
        }

        if (collision.gameObject.tag == "Player")
        {
            Instantiate(PoisonCircle, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }

  
}
