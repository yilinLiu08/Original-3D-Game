using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { private set; get; }

    public VoidEventSO saveDataEvent;

    private List<ISaveable> saveableList = new List<ISaveable>();

    private Data saveData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this.gameObject);

        //saveData = LoadData("Save");
        //if (saveData == null)
        //{
        //    saveData = new Data();
        //}
        saveData = new Data();
    }
    private void OnEnable()
    {
        saveDataEvent.OnEventRaised += Save;
    }

    private void OnDisable()
    {
        saveDataEvent.OnEventRaised -= Save;
    }

    private void Update()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            Load();
        }
    }


    public void RegisterSaveData(ISaveable saveable)
    {
        if (!saveableList.Contains(saveable))
        {
            saveableList.Add(saveable);
        }
    }
    public void UnRegisterSaveData(ISaveable saveable)
    {
        saveableList.Remove(saveable);
    }

    public void Save()
    {

        foreach (var saveable in saveableList)
        {
            saveable.GetSaveData(saveData);
        }
        SaveData(saveData, "Save");
        //foreach (var item in saveData.characterPosDict)
        //{
        //    Debug.Log(item.Key + "   " + item.Value);
        //}
        Debug.Log("±£´æ³É¹¦");
    }

    public void Load()
    {
        foreach (var saveable in saveableList)
        {
            saveable.LoadData(saveData);
        }

    }

    private string GetPath(string path)
    {
        if (Application.isEditor)
        {
            return Application.streamingAssetsPath + "/" + path + ".data";
        }

        return Application.persistentDataPath + "/" + path + ".data";
    }

    private Data LoadData(string path)
    {
        Data value = null;
        string path2 = GetPath(path);
        if (File.Exists(path2))
        {
            FileStream fileStream = new FileStream(path2, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                value = (Data)binaryFormatter.Deserialize(fileStream);
            }
            catch (Exception)
            {
                fileStream.Close();
                throw;
            }
            fileStream.Close();
        }
        return value;
    }

    private void SaveData(Data data, string path)
    {
        string path2 = GetPath(path);
        string directoryName = Path.GetDirectoryName(path2);
        if (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName);
        }
        FileStream fileStream = new FileStream(path2, FileMode.OpenOrCreate);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, data);
        fileStream.Flush();
        fileStream.Close();
    }
}

