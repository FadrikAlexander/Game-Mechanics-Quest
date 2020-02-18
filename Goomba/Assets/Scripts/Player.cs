using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        //Get the Mouse Position and move to it
        gameObject.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    //Called when the Player is killed
    public void KillPlayer()
    {
        Destroy(this.gameObject);
    }
}
