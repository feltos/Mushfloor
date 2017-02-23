using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
   
	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        ShotBasic shot = collision.gameObject.GetComponent<ShotBasic>();
        if(shot != null)
        {
            if(shot)
            {
                Destroy(shot.gameObject);
            }
        }
    }
}
