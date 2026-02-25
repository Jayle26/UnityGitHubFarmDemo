using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveAndLoadData : MonoBehaviour
{
    public Bag mybag;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SaveData()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/game_SaveData"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_SaveData");
        }
        FileStream file = File.Create(Application.persistentDataPath + "/game_SaveData/mybag.txt");
        var json = JsonUtility.ToJson(mybag);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(file, json);
        file.Close();
    }
    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/game_SaveData/mybag.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/game_SaveData/mybag.txt", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            JsonUtility.FromJsonOverwrite(formatter.Deserialize(file).ToString(), mybag);
            file.Close();
        }
        InventoryManager._instance.UpDateInventory();
    }
}
