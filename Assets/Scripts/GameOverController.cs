using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    public Text finalScoretext;

    void Start ()
    {
        finalScoretext.text = "Your final score is: " + StaticData.points;
    }

	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("IntroScene");
        }
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
	}
}
