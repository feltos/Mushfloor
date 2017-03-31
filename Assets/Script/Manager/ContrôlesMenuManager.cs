using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using UnityEngine.SceneManagement;

public class ContrôlesMenuManager : MonoBehaviour
{
    float NextSceneTimer = 0f;
    float NextSceneCooldown = 1.5f;
	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		NextSceneTimer += Time.deltaTime;
        if((NextSceneTimer >= NextSceneCooldown) && (InputManager.AnyKeyIsPressed || Input.GetKey(KeyCode.Joystick1Button0)))
        {
            SceneManager.LoadScene(2);
        }
	}

    
}
