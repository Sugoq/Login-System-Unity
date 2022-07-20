using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Server : MonoBehaviour
{
    public static Server instance;
    SaveData currentSaveData;
    public SaveData CurrentSaveData => currentSaveData;
              
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }        
        instance = this;
        DontDestroyOnLoad(gameObject);                   
    }
      
    public void Save(SaveData saveData)
    {        
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/{saveData.name}.dat";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, saveData);
        stream.Close();
        currentSaveData = saveData;
    }    
   
    public void Load(string name, out SaveData saveData)
    {
        string path = Application.persistentDataPath + $"/{name}.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            currentSaveData = formatter.Deserialize(stream) as SaveData;
            saveData = currentSaveData;
            stream.Close();
        }
        else saveData = null;
    }
   
    public void Register(SaveData saveData)
    {
        Save(saveData);
        currentSaveData = saveData;
    }

    public bool CheckUser(string name)
    {
        string path = Application.persistentDataPath + $"/{name}.dat";
        return (File.Exists(path));                
    }
}
