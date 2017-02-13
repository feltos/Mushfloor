using System.Collections;
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

    void Awake()
    {
        Target = GameObject.Find("Player");
    }

    void Start ()
    {
    
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
}
