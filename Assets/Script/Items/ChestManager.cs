using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    [SerializeField]
    Animator Chest;
    [SerializeField]
    GameObject[] Items;
    bool ChestOpen = false;
    [SerializeField]
    GameObject SpawnPoint;
    [SerializeField]PlayerManager PlayerScript;
    float BasicKeyHold;
    

    void Start ()
    {
		
	}
	
	
        
	void Update ()
    {
        Debug.Log(PlayerScript.GetKeyHold());
        BasicKeyHold = PlayerScript.GetKeyHold();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player") && !ChestOpen && BasicKeyHold > 0)
        {
            Chest.enabled = true;
            Instantiate(Items[UnityEngine.Random.Range(0,3)],SpawnPoint.transform.position,SpawnPoint.transform.rotation);
            ChestOpen = true;
            PlayerScript.SetKeyHold();
        }
    }
}
