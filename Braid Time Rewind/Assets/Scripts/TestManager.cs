using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Reload the Scene when pressing the Button 'R'
public class TestManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ResetScene();
    }

    void ResetScene()
    {
        SceneManager.LoadScene(0);
    }
}
