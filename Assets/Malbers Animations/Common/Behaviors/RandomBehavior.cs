﻿using UnityEngine;
using System.Collections;


namespace MalbersAnimations
{
    /// <summary>
    /// Is Used to execute random animations in a State Machine 
    /// </summary>
    public class RandomBehavior : StateMachineBehaviour
    {
        public string Parameter = "IDInt";
        public int Range;

        override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
            animator.SetInteger(Parameter, Random.Range(1, Range + 1));
        }
    }
}