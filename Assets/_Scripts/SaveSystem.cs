using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem
{
    public static void SaveProgress(Progress progress)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/letters.fil";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(progress);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadProgress()
    {
        string path = Application.persistentDataPath + "/letters.fil";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
