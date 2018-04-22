using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceDetection : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<CourtManager>().Bounced();
    }
}
