using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDetection : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name.ToLower() == "east wall") { transform.GetComponentInParent<CourtManager>().UpdateScore(true); }
        else if (gameObject.name.ToLower() == "west wall") { transform.GetComponentInParent<CourtManager>().UpdateScore(false); }
    }
}
