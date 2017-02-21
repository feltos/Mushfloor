using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeMonster : MonoBehaviour
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
    [SerializeField]GameObject FlamesCircle;

    void Awake()
    {
        Target = GameObject.Find("Player");
    }

    void Start ()
    {
		
	}
	
	
	void Update ()
    {
        Direction = (Target.transform.position - transform.position);
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

        if (collision.gameObject.tag == "Player")
        {
            Instantiate(FlamesCircle, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }

  
}
