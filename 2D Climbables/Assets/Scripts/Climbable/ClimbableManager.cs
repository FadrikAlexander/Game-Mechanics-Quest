using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbableManager : MonoBehaviour
{
    [SerializeField] GameObject startCollider, endCollider;

    [SerializeField] float ClimbingSpeed = 0.5f;

    //At the Start of the Game send to the Colliders the start and end point of the Climbable
    public void SetUpPlayer(GameObject Player, bool isDown)
    {
        PlayerMovement playerMovement = Player.GetComponent<PlayerMovement>();
        playerMovement.SetClimbableData(true, startCollider.transform.position, endCollider.transform.position, isDown, ClimbingSpeed);
    }
    public void PlayerOffClimbable(GameObject Player)
    {
        PlayerMovement playerMovement = Player.GetComponent<PlayerMovement>();
        playerMovement.OffClimbable();
    }
}
