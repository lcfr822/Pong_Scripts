using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public AudioClip startClip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(StartGame());
        }
	}

    IEnumerator StartGame()
    {
        GetComponent<AudioSource>().PlayOneShot(startClip);
        yield return new WaitForSeconds(startClip.length);
        SceneManager.LoadScene(1);
    }
}
