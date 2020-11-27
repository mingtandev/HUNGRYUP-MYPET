using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveLoadManager
{
    public static void SaveData(GameData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gamedata.dat";

        FileStream stream = new FileStream(path , FileMode.Create);

        formatter.Serialize(stream , data);

        stream.Close();
    }


    public static GameData LoadData()
    {
        string path = Application.persistentDataPath + "/gamedata.dat";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path,FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;

            return data;
        }
        else
        {
            Debug.LogError("File not exist");
            return null;
        }
    }



    
}
