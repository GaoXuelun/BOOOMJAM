using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public Transform playerTrans;
    public Vector3 startPosition;
    public Vector3 menuPosition;
    public float fadeDuration;

    [Header("Event Listen")]
    public SceneLoadEventSO loadEventSO;
    public VoidEventSO newGameEvent;

    [Header("Broadcast")]
    public VoidEventSO afterSceneLoadedEvent;
    public FadeEventSO fadeEvent;
    public SceneLoadEventSO unLoadedSceneEvent;

    [Header("Scene")]
    public GameSceneSO menuScene;
    public GameSceneSO firstLoadScene;
    private GameSceneSO sceneToLoad;
    [SerializeField] private GameSceneSO currentLoadedScene;

    private Vector3 positionToGo;
    private bool isLoading;
    private bool fadeScreen;

    private void Awake()
    {
        // Addressables.LoadSceneAsync(firstLoadScene.sceneReference, LoadSceneMode.Additive);

        // currentLoadedScene = firstLoadScene;
        // currentLoadedScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive);
    }

    private void Start()    // renew after main menu
    {
        loadEventSO.RaiseLoadRequestEvent(menuScene, menuPosition, true);
        // NewGame();
    }
    
    private void OnEnable()
    {
        loadEventSO.LoadRequestEvent += OnLoadRequestEvent;
        newGameEvent.OnEventRaised += NewGame;
    }
    private void OnDisable()
    {
        loadEventSO.LoadRequestEvent -= OnLoadRequestEvent;
        newGameEvent.OnEventRaised -= NewGame;
    }

    private void NewGame()
    {
        sceneToLoad = firstLoadScene;
        // OnLoadRequestEvent(sceneToLoad, startPosition, true);
        loadEventSO.RaiseLoadRequestEvent(sceneToLoad, startPosition, true);
    }

    private void OnLoadRequestEvent(GameSceneSO locationToLoad, Vector3 posToGo, bool fadeScreen)
    {
        if (isLoading)  return;
        isLoading = true;
        sceneToLoad = locationToLoad;
        positionToGo = posToGo;
        this.fadeScreen = fadeScreen;
        // Debug.Log(sceneToLoad.sceneReference.SubObjectName);
        if (currentLoadedScene != null) StartCoroutine(UnLoadPreviousScene());
        else LoadNewScene();
    }

    private IEnumerator UnLoadPreviousScene()
    {
        if (fadeScreen) fadeEvent.FadeIn(fadeDuration);
        
        yield return new WaitForSeconds(fadeDuration);
        unLoadedSceneEvent.RaiseLoadRequestEvent(sceneToLoad, positionToGo, true);
        yield return currentLoadedScene.sceneReference.UnLoadScene();
        playerTrans.gameObject.SetActive(false);
        LoadNewScene();
    }

    private void LoadNewScene()
    {
        var loadingOption = sceneToLoad.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
        loadingOption.Completed += OnloadCompleted;
    }

    private void OnloadCompleted(AsyncOperationHandle<SceneInstance> obj)
    {
        currentLoadedScene = sceneToLoad;
        playerTrans.position = positionToGo;
        playerTrans.gameObject.SetActive(true);

        if (fadeScreen) fadeEvent.FadeOut(fadeDuration);
        isLoading = false;
        
        if (currentLoadedScene.sceneType == SceneType.Location) afterSceneLoadedEvent.RaiseEvent();
    }
}
