using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    [Header("Event Listen")]
    public VoidEventSO saveDataEvent;

    private List<SaveableInterface> saveableList = new List<SaveableInterface>();
    private Data saveData;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);

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

    public void RegisterSaveData(SaveableInterface saveable)
    {
        if (!saveableList.Contains(saveable)) saveableList.Add(saveable);
    }
    public void UnRegisterSaveData(SaveableInterface saveable)
    {
        saveableList.Remove(saveable);
    }

    public void Save()
    {
        foreach (var saveable in saveableList)
        {
            saveable.GetSaveData(saveData);
        }
        foreach (var item in saveData.characterPosDict)
        {
            Debug.Log(item.Key + " " + item.Value);
        }
    }
    public void Load()
    {

    }
}
