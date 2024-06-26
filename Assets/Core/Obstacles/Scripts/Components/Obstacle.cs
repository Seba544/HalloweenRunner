using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    protected string _obstacleId;
    public ObstacleType obstacleType;
    public string GetObstacleId() => _obstacleId;
    
}

public enum ObstacleType
{
    SLIME_PLATFORM,
    SNAIL
}
