using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterData : MonoBehaviour, SaveableInterface
{
    [Header("Event Listen")]
    public VoidEventSO newGameEvent;

    [Header("Character Data")]
    public float maxHP;
    public float currentHP;

    public DataDefinition dataDefinition;
    
    private void NewGame()
    {
        currentHP = maxHP;
        // OnHealthChange?.Invoke(this);
    }

    private void OnEnable()
    {
        newGameEvent.OnEventRaised += NewGame;
        SaveableInterface saveable = this;
        saveable.RegisterSaveData();
    }
    private void OnDisable()
    {
        newGameEvent.OnEventRaised -= NewGame;
        SaveableInterface saveable = this;
        saveable.UnRegisterSaveData();
    }

    public DataDefinition GetDataID()
    {
        // throw new System.NotImplementedException();
        return dataDefinition;
    }
    public void GetSaveData(Data data)
    {
        if (data.characterPosDict.ContainsKey(GetDataID().ID))
        {
            data.characterPosDict[GetDataID().ID] = transform.position;
        }
        else
        {
            data.characterPosDict.Add(GetDataID().ID, transform.position);
        }
    }
    public void LoadData(Data data)
    {
        if (data.characterPosDict.ContainsKey(GetDataID().ID))
        {
            transform.position = data.characterPosDict[GetDataID().ID];
        }
    }
}
