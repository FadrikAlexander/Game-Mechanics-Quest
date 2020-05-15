using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simple Class to move the Player around the map
public class PlayerMovement : MonoBehaviour
{
    //Map Boundries
    Vector2 BoundriesX;
    Vector2 BoundriesY;
    MapBounderies mapBounderies;

    [SerializeField] float Speed = 7.5f;

    void Awake()
    {
        GetMapBoundries();
    }

    //Get Map Bounderies and save them for clamping
    void GetMapBoundries()
    {
        if (mapBounderies == null)
            mapBounderies = FindObjectOfType<MapBounderies>();

        BoundriesX = mapBounderies.GetXVector();
        BoundriesY = mapBounderies.GetYVector();
    }

    void FixedUpdate()
    {
        Move();
        ClampMovement();
    }

    void Move() //Simple two input Code
    {
        float inputHor = Input.GetAxis("Horizontal");
        gameObject.GetComponent<Transform>().Translate(Vector3.right * inputHor * Speed * Time.deltaTime);

        float inputVer = Input.GetAxis("Vertical");
        gameObject.GetComponent<Transform>().Translate(Vector3.up * inputVer * Speed * Time.deltaTime);
    }

    void ClampMovement() //Clamp the movement inside the map boundries
    {
        gameObject.GetComponent<Transform>().position = new Vector2(
                                                            Mathf.Clamp(gameObject.GetComponent<Transform>().position.x, BoundriesX.y, BoundriesX.x),
                                                            Mathf.Clamp(gameObject.GetComponent<Transform>().position.y, BoundriesY.y, BoundriesY.x)
                                                            );
    }
}
