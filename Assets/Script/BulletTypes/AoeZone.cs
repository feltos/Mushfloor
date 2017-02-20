using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeZone : MonoBehaviour
{
    [SerializeField]
    PlayerManager Player;
    float Damage = 1;

    void Awake()
    {
        
    }

    void Start ()
    {
		
	}
	
	
	void Update ()
    {
        
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Player.LoseHP(Damage);
        }
        
    }
}
