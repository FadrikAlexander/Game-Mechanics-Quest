using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaController : MonoBehaviour
{
    //To check out which direction we're walking
    bool movingDirection = false;

    //Goomba Speed
    [SerializeField] float speed;
    void Update()
    {
        transform.Translate(((movingDirection ? -1 : 1) * Vector3.left * Time.deltaTime * speed));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Kill The Player
            other.gameObject.GetComponent<Player>().KillPlayer();
        }
        if (other.gameObject.tag == "Edge" || other.gameObject.tag == "Enemy")
        {
            //Reverse Direction
            movingDirection = !movingDirection;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Being Killed
            Destroy(this.gameObject);
            //AddScore
        }
    }

    #region LegsAnimation 
    //Just to flip the SpriteRenderer of the legs according to the speed of the Goomba
    [SerializeField] SpriteRenderer legs;

    void Awake()
    {
        StartCoroutine(LegsShuffle());
    }
    IEnumerator LegsShuffle()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / speed);
            legs.flipX = !legs.flipX;
        }
    }
    #endregion
}
