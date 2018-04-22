using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PongPaddle : MonoBehaviour {
    public float moveSpeed;

    public bool isP1;

    float maxY, minY;

    Vector2 clampPos;

    Image paddleImg;

	void Start () {
        maxY = 3.8f;
        minY = -3.8f;

        paddleImg = GetComponent<Image>();
	}
	
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
                if (Input.GetAxis("P1_MV") != 0)
                {
                    GetComponent<RectTransform>().Translate(Vector3.up * moveSpeed * Input.GetAxis("P1_MV"), Space.Self);
                    clampPos = paddleImg.rectTransform.position;
                    clampPos.y = Mathf.Clamp(paddleImg.rectTransform.position.y, minY, maxY);
                    paddleImg.rectTransform.position = clampPos;
                }
            }
            else
            {
                if (Input.GetAxis("P2_MV") != 0)
                {
                    GetComponent<RectTransform>().Translate(Vector3.up * moveSpeed * Input.GetAxis("P2_MV"), Space.Self);
                    clampPos = paddleImg.rectTransform.position;
                    clampPos.y = Mathf.Clamp(paddleImg.rectTransform.position.y, minY, maxY);
                    paddleImg.rectTransform.position = clampPos;
                }
            }
        }
    }
}
