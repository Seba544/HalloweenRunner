
using System;
using System.Collections.Generic;

[Serializable]
public class WorldProgression
{
    public string World;
    public List<int> LevelsCompleted;
    public WorldProgression(string world, List<int> levelsCompleted)
    {
        World = world;
        LevelsCompleted = levelsCompleted;
    }
}
