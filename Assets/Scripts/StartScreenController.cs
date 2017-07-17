using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenController : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("MainScene");
            StaticData.lives = 3;
            StaticData.playerDead = false;
            StaticData.points = 0;
            StaticData.treasure = 1;
        }
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
	}
}
