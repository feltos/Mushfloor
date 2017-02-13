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
}
