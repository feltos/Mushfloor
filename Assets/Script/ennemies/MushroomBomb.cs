using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBomb : MonoBehaviour
{

    [SerializeField]
    GameObject PoisonCircle;
	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(PoisonCircle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
