using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // public PlayerStatBar playerStatBar;

    [Header("Event Listen")]
    // public CharacterEventSO healthEvent;
    public SceneLoadEventSO loadEventSO;

    private void OnEnable()
    {
        // healthEvent.OnEventRaised += OnhealthEvent;
        loadEventSO.LoadRequestEvent += OnLoadEvent;
    }
    private void OnDisable()
    {
        // healthEvent.OnEventRaised -= OnhealthEvent;
        loadEventSO.LoadRequestEvent -= OnLoadEvent;
    }

    // private void OnhealthEvent(Character character)
    // {
    //     var persentage = character.currentHealth / character.maxHealth;
    //     playerStatBar.OnHealthChange(persentage);
    // }
    private void OnLoadEvent(GameSceneSO sceneToLoad, Vector3 posToGo, bool fadeScreen)
    {
        var isMenu = sceneToLoad.sceneType == SceneType.Menu;
        // playerStatBar.gameObject.SetActive(!isMenu);
    }
}
