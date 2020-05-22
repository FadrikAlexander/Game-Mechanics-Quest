using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Move", menuName = "New Move")]
public class Move : ScriptableObject
{
    [SerializeField] List<KeyCode> movesKeyCodes; //the List and order of the Moves
    [SerializeField] Moves moveType; //The kind of the move
    [SerializeField] int ComboPriorty = 0; //the more complicated the move the higher the Priorty

    public bool isMoveAvilable(List<KeyCode> playerKeyCodes) //Check if we can perform this move from the entered keys
    {
        int comboIndex = 0;

        for (int i = 0; i < playerKeyCodes.Count; i++)
        {
            if (playerKeyCodes[i] == movesKeyCodes[comboIndex])
            {
                comboIndex++;
                if (comboIndex == movesKeyCodes.Count) //The end of the Combo List
                    return true;
            }
            else
                comboIndex = 0;
        }
        return false;
    }

    //Getters
    public int GetMoveComboCount()
    {
        return movesKeyCodes.Count;
    }
    public int GetMoveComboPriorty()
    {
        return ComboPriorty;
    }
    public Moves GetMove()
    {
        return moveType;
    }
}
