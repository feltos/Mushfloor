using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Contributeurs : Secret
public class TreeManager : MonoBehaviour
{	
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
