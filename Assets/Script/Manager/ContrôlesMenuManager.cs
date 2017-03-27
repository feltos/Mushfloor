using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using UnityEngine.SceneManagement;

public class ContrôlesMenuManager : MonoBehaviour
{
    float NextSceneTimer = 0f;
    float NextSceneCooldown = 0.5f;
	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		NextSceneTimer += Time.deltaTime;
        if(NextSceneTimer >= NextSceneCooldown && InputManager.AnyKeyIsPressed)
        {
            SceneManager.LoadScene(0);
        }
	}

    
}
