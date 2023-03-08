using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveWorldProgression(WorldProgression worldProgression){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/"+worldProgression.World+".sav";
        FileStream stream = new FileStream(path,FileMode.Create);
        formatter.Serialize(stream,worldProgression);
        stream.Close();
    }

    public static WorldProgression LoadWorldProgression(string World){
        string path = Application.persistentDataPath +"/"+World+".sav";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            WorldProgression worldProgression = formatter.Deserialize(stream) as WorldProgression;
            stream.Close();
            return worldProgression;
        }else{
            Debug.LogError("Save file not found in "+path);
            return null;
        }
    }
}
