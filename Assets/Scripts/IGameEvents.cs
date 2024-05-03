using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Pause();
public interface IGameEvents
{
    public event Pause OnPause;
}
