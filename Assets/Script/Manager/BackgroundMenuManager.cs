using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMenuManager : MonoBehaviour
{

    [SerializeField]
    GameObject Spawn;
    [SerializeField]
    GameObject DeSpawn;
    float Speed = 2;
 

	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.gameObject.layer == LayerMask.NameToLayer("DeSpawn"))
        {
            
            transform.position = Spawn.transform.position;
        }
    }

}
