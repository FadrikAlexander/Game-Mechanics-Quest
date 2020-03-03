using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    //List of all the controls that are allowed in the game.
    //So the time don't move forward when pressing a non control button.
    [SerializeField] List<KeyCode> AllowedKeys;

    //The Speed the Time speed up and down.
    [SerializeField] float timeScaleAccelrationSpeed;

    bool noKey = true;
    bool isFast = false;

    void Awake()
    {
        //Start Forzen
        Time.timeScale = 0.05f;

        //Smoothing the TimeScale
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
    void Update()
    {
        noKey = true;
        //if the player pressed Any Allowed Key
        foreach (KeyCode key in AllowedKeys)
            if (Input.GetKey(key))
            {
                noKey = false;
                //Speed Up time
                Time.timeScale = Mathf.MoveTowards(Time.timeScale, 1, timeScaleAccelrationSpeed);

                //Smoothing the TimeScale
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                break;
            }

        //if no Key Pressed
        if (noKey)
        {
            //Speed Down time
            Time.timeScale = Mathf.MoveTowards(Time.timeScale, 0.05f, timeScaleAccelrationSpeed / 2);

            //Smoothing the TimeScale
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }
}
