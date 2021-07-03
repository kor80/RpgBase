using System.Collections;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance {get; private set; }
    public int level;
    public float experience;
    public string name;
    private Vector3 playerPosition;

    private void Awake() 
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }    

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class Data
    {
        public int level;
        public float experience;
        public string name;
        public Vector3 position;
    }

    public void SaveData()
    {
        Data data = new Data();
        data.level = level;
        data.experience = experience;
        data.name = name;
        data.position = playerPosition;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "savedata.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "savedata.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);
            
            level = data.level; 
            experience = data.experience;
            name = data.name;
            playerPosition = data.position;
        }
    }

}
