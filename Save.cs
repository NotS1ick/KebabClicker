using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    public static void SaveGame()
    {
        PlayerData data = new PlayerData();
        data.timesPressed = KebabClick.timesPressed;
        // data.boughtItems = Store.boughtItems;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savegame.json", json);
        Debug.Log("Save file path: " + Application.persistentDataPath + "/savegame.json");
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savegame.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Game loaded successfully!");
            ApplyLoadedData(data);
            SceneManager.LoadSceneAsync(2);
        }
        else
        {
            Debug.LogWarning("Save file not found!");
        }
    }

    private void ApplyLoadedData(PlayerData data)
    {
        if (data != null)
        {
            KebabClick.timesPressed = data.timesPressed;
        }
    }

    public void NewGame()
    {
        PlayerData newData = new PlayerData
        {
            timesPressed = 0,
            boughtItems = new List<string>()
        };

        string json = JsonUtility.ToJson(newData);
        File.WriteAllText(Application.persistentDataPath + "/savegame.json", json);
        Debug.Log("New game created and saved!");
        ApplyLoadedData(newData);
        SceneManager.LoadSceneAsync(2);
    }
}

[System.Serializable]
public class PlayerData
{
    public float timesPressed;
    public List<string> boughtItems;
}