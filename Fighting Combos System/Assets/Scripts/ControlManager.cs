using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ControlManager : MonoBehaviour
{
    [SerializeField] float ComboResetTime = 0.5f; //The Time to reset the Combo Time
    [SerializeField] List<KeyCode> KeysPressed; //List of all the Keys Pressed so far

    [SerializeField] Text controlsTestText; //Just for testing for printing the keys

    MovesManager movesManager;
    void Awake()
    {
        if (movesManager == null)
            movesManager = FindObjectOfType<MovesManager>();
    }

    void Update()
    {
        DetectPressedKey(); //Get the Pressed Key

        PrintControls(); //Just for testing
    }

    public void DetectPressedKey()
    {
        //Go through all the Keys
        //To make it faster we can attach a class and put all the keys that are allowed to be pressed
        //This will make the process a bit faster rather than moving through all keys
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                KeysPressed.Add(kcode); //Add the Key to the List

                if (!movesManager.CanMove(KeysPressed)) //if there is no avilable Moves reset the list
                    StopAllCoroutines();

                StartCoroutine(ResetComboTimer()); //Start the Reseting process
            }
        }
    }

    public void ResetCombo() //Called to Reset the Combo after a move
    {
        KeysPressed.Clear();
    }

    IEnumerator ResetComboTimer()
    {
        yield return new WaitForSeconds(ComboResetTime);

        movesManager.PlayMove(KeysPressed); //Run the move from the list
        KeysPressed.Clear(); //Empty the list
    }

    public void PrintControls() //Printing Keys just for testing
    {
        controlsTestText.text = " Keys Pressed (";

        foreach (KeyCode kcode in KeysPressed)
            controlsTestText.text += kcode + ",";

        controlsTestText.text += ")";
    }
}
