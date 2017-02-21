using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeZone : MonoBehaviour
{
    [SerializeField]
    PlayerManager Player;
    [SerializeField]
    LittleMonster LittleM;
    [SerializeField]
    HeavyMonster HeavyM;
    [SerializeField]
    ArcMonster ArcM;
    [SerializeField]
    RafaleEnemy RafaleM;
    float Damage = 1;

    void Awake()
    {
        
    }

    void Start ()
    {
        Destroy(gameObject,10);
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
        if (collision.gameObject.tag == ("LittleM"))
        {
            LittleM.LoseHP(Damage);
        }
        if(collision.gameObject.tag == ("HeavyM"))
        {
            HeavyM.LoseHP(Damage);
        }
        if(collision.gameObject.tag == ("ArcM"))
        {
            ArcM.LoseHP(Damage);
        }
        if(collision.gameObject.tag == ("RafaleM"))
        {
            RafaleM.LoseHP(Damage);
        }
    }
}
