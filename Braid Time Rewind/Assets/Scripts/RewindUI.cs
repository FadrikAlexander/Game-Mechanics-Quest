using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is just to show the UI rewind button
public class RewindUI : MonoBehaviour
{
    [SerializeField] GameObject UI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            UI.SetActive(true);

        if (Input.GetKeyUp(KeyCode.Space))
            UI.SetActive(false);
    }
}
