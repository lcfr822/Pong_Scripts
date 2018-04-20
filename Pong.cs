using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Pong : MonoBehaviour {
    public float moveSpeed;

    public bool isP1;

    float maxY, minY;

	// Use this for initialization
	void Start () {
        maxY = 4;
        minY = -4;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            FindObjectOfType<CourtManager>().GameRunning = false;
        }
	}

    private void FixedUpdate()
    {
        if (FindObjectOfType<CourtManager>().GameRunning)
        {
            if (isP1)
            {
                if (Input.GetButton("P1_UP") && gameObject.GetComponent<Image>().rectTransform.position.y < maxY) { GetComponent<RectTransform>().Translate(Vector3.up * moveSpeed, Space.Self); }
                else if (Input.GetButton("P1_DN") && gameObject.GetComponent<Image>().rectTransform.position.y > minY) { GetComponent<RectTransform>().Translate(-Vector3.up * moveSpeed, Space.Self); }
            }
            else
            {
                if (Input.GetButton("P2_UP") && gameObject.GetComponent<Image>().rectTransform.position.y < maxY) { GetComponent<RectTransform>().Translate(Vector3.up * moveSpeed, Space.Self); }
                else if (Input.GetButton("P2_DN") && gameObject.GetComponent<Image>().rectTransform.position.y > minY) { GetComponent<RectTransform>().Translate(-Vector3.up * moveSpeed, Space.Self); }
            }
        }
    }
}
