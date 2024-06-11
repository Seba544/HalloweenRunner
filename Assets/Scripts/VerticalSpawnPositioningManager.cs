using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class VerticalSpawnPositioningManager : MonoBehaviour
{
    public List<HeightLevelSpawnPosition> HeightLevels;
    private void Start()
    {
        SetVerticalSpawnPosition();
    }

    private void SetVerticalSpawnPosition()
    {
        var heightLevel = HeightLevels[Random.Range(0, HeightLevels.Count)];
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + heightLevel.OffsetY, 0);
    }
        
    
}

[Serializable]
public class HeightLevelSpawnPosition
{
    public HeightLevel HeightLevel;
    public float OffsetY;
}

public enum HeightLevel
{
    LOW,
    MIDDLE,
    HIGH
}
