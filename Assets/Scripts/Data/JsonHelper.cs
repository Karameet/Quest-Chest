using UnityEngine;
using System.IO;

public static class JsonHelper
{
    public static bool SaveData<T>(T Data,string fileName) 
    {
        string path = Application.persistentDataPath + $"/{fileName}.json";

        string json = JsonUtility.ToJson(Data);

        File.WriteAllText(path, json);

        Debug.Log("Save : " + path);
        return true;
    }

    public static bool LoadData<T>(ref T data,string fileName)
    {
        string path = Application.persistentDataPath + $"/{fileName}.json";

        if (!File.Exists(path))
        {
            Debug.Log($"Not found Data in path {path}");
            return false;
        }

        var json = File.ReadAllText(path);

        JsonUtility.FromJsonOverwrite(json, data);

        Debug.Log("Load : " + path);
        return true;
    }
}
