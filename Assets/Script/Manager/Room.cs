using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Room : MonoBehaviour
{

    public List<GameObject>Ennemies;
    [SerializeField]
    GameObject[] Items;
    bool EnnemiesDown = true;
  



    void Awake ()
    {
        foreach(var e in Ennemies)
        {
            e.GetComponent<AllEnemiesManager>().room = this;
        }
        Desactivate();
       
	}
	
	public void RemoveEnemy(GameObject enemy)
    {
        Ennemies.Remove(enemy);
    }
	void Update ()
    {      
        

        if(Ennemies.Count == 0 && EnnemiesDown)
        {
            DropItem();
        }
    }

    public void Desactivate()
    {
       foreach(var e in Ennemies)
        {
            if(e != null)
            {
                e.SetActive(false);
            }
        }
    }
    public void Activate()
    {
        foreach (var e in Ennemies)
        {
            if(e != null)
            {
                e.SetActive(true);
                e.GetComponent<AllEnemiesManager>().Init();
                e.GetComponent<AllEnemiesManager>().Reset();
            }
        }
    }

    public void DropItem()
    {           
            Instantiate(Items[UnityEngine.Random.Range(0, 3)], transform.position + Vector3.up * 2, transform.rotation);
            EnnemiesDown = false;             
    }



}
