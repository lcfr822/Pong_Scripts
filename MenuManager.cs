using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public AudioClip startClip;

    public CanvasGroup controlGroup;

    public Button qButton;

	// Use this for initialization
	void Start () {
        if (Application.platform == RuntimePlatform.WebGLPlayer) { Destroy(qButton.gameObject); }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump") && !Input.GetButton("Fire1")) { StartCoroutine(StartGame()); }
        else if (Input.GetButtonDown("Fire1")) { controlGroup.alpha = 1; }
        else if (Input.GetButtonUp("Fire1")) { controlGroup.alpha = 0; }
	}

    /// <summary>
    /// Close the application.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Delays the transition between levels long enough to play the start sound.
    /// </summary>
    /// <returns>WaitForSeconds equal to the length of the start clip.</returns>
    IEnumerator StartGame()
    {
        GetComponent<AudioSource>().PlayOneShot(startClip);
        yield return new WaitForSeconds(startClip.length);
        SceneManager.LoadScene(1);
    }
}
