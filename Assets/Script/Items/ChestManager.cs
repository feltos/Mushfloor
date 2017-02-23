using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    [SerializeField]
    Animator Chest;
	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Chest.enabled = true;
        }
    }
}
