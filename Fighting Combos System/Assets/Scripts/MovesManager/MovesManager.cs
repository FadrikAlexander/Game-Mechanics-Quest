using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesManager : MonoBehaviour
{
    [SerializeField] List<Move> avilableMoves; //All the Avilable Moves
    PlayerController playerController;
    ControlManager controlManager;

    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        controlManager = FindObjectOfType<ControlManager>();

        avilableMoves.Sort(Compare); //Sort all the moves based on thier prioraty
    }

    public bool CanMove(List<KeyCode> keycodes) //return true if the list contain a move
    {
        foreach (Move move in avilableMoves)
        {
            if (move.isMoveAvilable(keycodes))
                return true;
        }
        return false;
    }

    public void PlayMove(List<KeyCode> keycodes) //Send the moves to the player starting from the highest priorty
    {
        foreach (Move move in avilableMoves)
        {
            if (move.isMoveAvilable(keycodes))
            {
                playerController.PlayMove(move.GetMove(), move.GetMoveComboPriorty());
                break;
            }
        }
    }

    public int Compare(Move move1, Move move2)
    {
        return Comparer<int>.Default.Compare(move2.GetMoveComboPriorty(), move1.GetMoveComboPriorty());
    }
}
