using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    [Header("Event Listen")]
    public VoidEventSO afterSceneLoadedEvent;


    private CinemachineConfiner confiner;

    private void Awake()
    {
        confiner = GetComponent<CinemachineConfiner>();
    }

    private void OnEnable()
    {
        afterSceneLoadedEvent.OnEventRaised += OnAfterSceneLoadedEvent;
    }

    private void OnDisable()
    {
        afterSceneLoadedEvent.OnEventRaised -= OnAfterSceneLoadedEvent;
    }

    private void OnAfterSceneLoadedEvent()
    {
        GetNewCameraBounds();
    }

    // private void Start()
    // {
    //     GetNewCameraBounds();
    // }

    private void GetNewCameraBounds()
    {
        var obj = GameObject.FindGameObjectWithTag("Bounds");
        if (obj == null) return;
        confiner.m_BoundingVolume = obj.GetComponent<BoxCollider>();
    }
}
