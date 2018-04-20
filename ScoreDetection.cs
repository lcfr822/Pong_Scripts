using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name.ToLower() == "east wall")
        {
            transform.GetComponentInParent<CourtManager>().UpdateScore(true);
        }
        else if (gameObject.name.ToLower() == "west wall")
        {
            transform.GetComponentInParent<CourtManager>().UpdateScore(false);
        }
    }
}
