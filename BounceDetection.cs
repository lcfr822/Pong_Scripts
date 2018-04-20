using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceDetection : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<CourtManager>().Bounced();
        if(collision.gameObject.name.ToLower() == "north wall") { GetComponent<Rigidbody2D>().AddForce(Vector2.down / Random.Range(85, 100), ForceMode2D.Impulse); }
        else if(collision.gameObject.name.ToLower() == "south wall") { GetComponent<Rigidbody2D>().AddForce(Vector2.up / Random.Range(85, 100), ForceMode2D.Impulse); }
        else if(collision.gameObject.name.ToLower() == "pongpaddle1") { GetComponent<Rigidbody2D>().AddForce(Vector2.right / Random.Range(85, 100), ForceMode2D.Impulse); }
        else if (collision.gameObject.name.ToLower() == "pongpaddle2") { GetComponent<Rigidbody2D>().AddForce(Vector2.left / Random.Range(85, 100), ForceMode2D.Impulse); }
    }
}
