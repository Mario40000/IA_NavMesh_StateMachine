using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour {

    public int score;


	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0, Time.deltaTime * 50, 0);
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StaticData.points += score;
            StaticData.treasure = 1;
            Destroy(gameObject);
        }
    }
}
