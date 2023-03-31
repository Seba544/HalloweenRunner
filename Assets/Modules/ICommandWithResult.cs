using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommandWithResult<T>
{
    T Execute();
}
