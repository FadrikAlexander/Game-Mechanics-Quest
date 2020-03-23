using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbableCollider : MonoBehaviour
{
    //Set to true for the Start Position of the Climbable
    [SerializeField] bool isDown;

    ClimbableManager climbableManager;

    void Awake()
    {
        climbableManager = GetComponentInParent<ClimbableManager>();
    }

    #region Triggers
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            climbableManager.SetUpPlayer(other.gameObject, isDown);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            climbableManager.PlayerOffClimbable(other.gameObject);
    }
    #endregion
}
