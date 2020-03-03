using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void FixedUpdate()
    {
        //Always Move Forward
        transform.Translate(Vector3.up * 20 * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if Hit the Player aka the Red Blocks
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
