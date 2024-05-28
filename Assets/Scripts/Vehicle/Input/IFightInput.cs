using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFightInput
{
    public event Action<float> MovementInputReceived;
    public event Action BrakeStartInputReceived;
    public event Action BrakeEndInputReceived;
    public event Action AttackInputReceived;
}
