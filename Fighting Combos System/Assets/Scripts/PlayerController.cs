using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Effect GameObjects
    [SerializeField] GameObject Fire;
    [SerializeField] GameObject Hook;

    Animator animator;
    ControlManager controlManager;

    int CurrentComboPriorty = 0;

    void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        if (controlManager == null)
            controlManager = FindObjectOfType<ControlManager>();
    }

    public void PlayMove(Moves move, int ComboPriorty) //Get the Move and the Priorty
    {
        if (Moves.None != move) //if the move is none ignore the function
        {
            if (ComboPriorty > CurrentComboPriorty) //if the new move is higher Priorty play it and ignore everything else
            {
                CurrentComboPriorty = ComboPriorty; //Set the new Combo
                ResetTriggers(); //Reset All Animation Triggers
                controlManager.ResetCombo(); //Reset the List in the ControlsManager
            }
            else
                return;

            //Set the Animation Triggers
            switch (move)
            {
                case Moves.Punch:
                    animator.SetTrigger("Punch");
                    break;
                case Moves.DownKick:
                    animator.SetTrigger("DownKick");
                    break;
                case Moves.UpKick:
                    animator.SetTrigger("UpKick");
                    break;

                case Moves.UpPunch:
                    animator.SetTrigger("UpPunch");
                    break;
                case Moves.UpperCut:
                    animator.SetTrigger("UpperCut");
                    break;
                case Moves.RoundKick:
                    animator.SetTrigger("RoundKick");
                    break;
                case Moves.FireBreath:
                    animator.SetTrigger("FireBreath");
                    break;
                case Moves.Knife:
                    animator.SetTrigger("Knife");
                    break;
                case Moves.Hook:
                    animator.SetTrigger("Hook");
                    break;
            }

            CurrentComboPriorty = 0; //Reset the Combo Priorty
        }
    }

    void ResetTriggers() //Reset All the Animation Triggers so we don't have overlapping animations
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            animator.ResetTrigger(parameter.name);
        }
    }

    //Effect Activation
    public void BreathFire()
    {
        Fire.SetActive(false);
        Fire.SetActive(true);
    }
    public void AddHook()
    {
        Hook.SetActive(true);
    }
    public void RemoveHook()
    {
        Hook.SetActive(false);
    }
}
