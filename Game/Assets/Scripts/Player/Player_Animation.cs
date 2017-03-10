﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// This class handles the players animations; extends from abstract animation
/// </summary>
public class Player_Animation : AbstractPlayer_Animation
{
    /// <summary>
    /// Called when the object is created
    /// </summary>
    protected override void Start()
    {
        _parentMoveScript = GetComponentInParent<AbstractPlayer_Movement>();            // Gets reference to the parent move script

        _playerAnimator = GetComponent<Animator>();                                     // Gets the animator component
        _playerAnimator.SetInteger("battle", 1);                                        // Sets the state of the player to "battle"
                                                                                        // (So the animations can work)
    }

    /// <summary>
    /// Called once per frame
    /// </summary>
    protected override void Update()
    {
        if (_parentMoveScript.GetIsMoving()) _playerAnimator.SetInteger("moving", 2);   // If moving
        else if (_parentMoveScript.GetIsAttacking()) _playerAnimator.SetInteger("moving", 3);
        else _playerAnimator.SetInteger("moving", 0);                                   // If not moving
    }
}
