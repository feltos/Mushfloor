using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    [SerializeField]
    Animator Chest;
    [SerializeField]
    GameObject[] GunsPrefab;
    bool ChestOpen = false;
    [SerializeField]
    GameObject SpawnPoint;
    PlayerManager PlayerScript;
    float BasicKeyHold;
    

    void Start ()
    {
        PlayerScript = GameObject.Find("Player").GetComponent<PlayerManager>();
	}
	
	
        
	void Update ()
    {        
        BasicKeyHold = PlayerScript.GetKeyHold();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player") && !ChestOpen && BasicKeyHold > 0)
        {
            SoundManager.Instance.ChestOpen();
            Chest.enabled = true;
            Instantiate(GunsPrefab[Random.Range(0,GunsPrefab.Length)],SpawnPoint.transform.position,SpawnPoint.transform.rotation);
            ChestOpen = true;
            PlayerScript.SetKeyHold();
        }
    }
}
