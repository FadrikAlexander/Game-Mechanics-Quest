using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpriteSpawner : MonoBehaviour
{
    //[Replace with a pooling system to make the game faster]
    [SerializeField] GameObject spritePrefab;

    SpriteRenderer spriteRenderer;

    //Time until spawning the next Ghost
    [SerializeField] float time = 0.2f;
    float currentTime = 0;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Called from the Update function in the movement Class either Player or Enemy
    public void StartSpawningGhost()
    {
        //Add the time amount each Update
        currentTime += Time.deltaTime;

        //When the time is reach
        if (currentTime >= time)
        {
            SpawnGhost();
            //Reset Time
            currentTime = 0;
        }
    }

    //Put a ghost on the scene
    void SpawnGhost()
    {
        //Start a new Ghost [Replace with a pooling system to make the game faster]
        GameObject ghost = Instantiate(spritePrefab, transform.position, Quaternion.identity);

        //Get the same sprite and flip direction 
        ghost.GetComponent<SpriteRenderer>().sprite = spriteRenderer.sprite;
        ghost.GetComponent<SpriteRenderer>().flipX = spriteRenderer.flipX;

        //Destroy the Ghost after a while [Replace with a pooling system to make the game faster]
        Destroy(ghost, 2f);
    }
}
