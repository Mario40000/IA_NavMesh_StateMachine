using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text scoreText;
    public Text livesText;
    public Text deadText;

    public GameObject player;
    public GameObject treasure;
    public Transform instancier;

    public Transform[] instanciers;

    private GameObject mainTheme;

	// Use this for initialization
	void Start ()
    {
        deadText.text = "";
        UpdateUI();
        Instantiate(player, instancier.position, Quaternion.identity);
        mainTheme = GameObject.Find("MainTheme");
        mainTheme.GetComponent<AudioSource>().Play();
        StaticData.treasure = 1;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        UpdateUI();

        //Hacemos aparecer tesoros
        if (StaticData.treasure == 1)
        {

            Instantiate(treasure, instanciers[Random.Range(0, instanciers.Length)].position, Quaternion.identity);
            StaticData.treasure = 0;
        }
        //Hacemos respawn si quedan vidas o acabamos la partida si no
        if (StaticData.playerDead == true && StaticData.lives > 0)
        {
            deadText.text = "You Die";
            StartCoroutine(Spawner());
        }

        if (StaticData.lives < 1)
        {
            deadText.text = "You Die";
            StartCoroutine(GameOver());
        }

	}
    //Metodo para actualizar la UI
    void UpdateUI()
    {
        scoreText.text = "Score: " + StaticData.points;
        livesText.text = "Lives: " + StaticData.lives;
    }

    //Metodo para acabar la partida
    IEnumerator GameOver ()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOverScene");
    }
    //Metodo para hacer respawn
    IEnumerator Spawner()
    {
        StaticData.playerDead = false;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainScene");
        
    }
}
