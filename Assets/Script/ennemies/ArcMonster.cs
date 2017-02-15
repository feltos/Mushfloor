using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcMonster : MonoBehaviour
{

    [SerializeField]
    int HP;
    [SerializeField]
    GameObject Target;
    Vector2 Direction;
    [SerializeField]
    Vector2 Speed;
    Vector2 Movement;
    [SerializeField]
    Rigidbody2D rb2dAM;

    void Awake()
    {
        Target = GameObject.Find("Player");
    }

    void Start ()
    {
		
	}
	
	
	void Update ()
    {
        Direction = Target.transform.position - transform.position;
        Movement = new Vector2(
            Speed.x * Direction.x,
            Speed.y * Direction.y);



	}

    void FixedUpdate()
    {
        rb2dAM.velocity = Movement;
    }

    void Fire()
    {

    }
}
