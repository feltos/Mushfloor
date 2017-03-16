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
        BulletBasic shot = collision.gameObject.GetComponent<BulletBasic>();
        if(shot != null)
        {
            if(shot)
            {
                Destroy(shot.gameObject);
            }
        }
    }
}
