using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboState :  BaseState
{
    [SerializeField] private float cooldownTime = 2f;
    [SerializeField] private float nextAttackTime = 0f;
    [SerializeField] private static int numOfClicks = 0;
    [SerializeField] private float lastClickedTime = 0;
    [SerializeField] private float maxComboDelay = 1;

    public override void StateUpdate()
    {

    }
}
