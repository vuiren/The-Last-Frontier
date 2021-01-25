using System;
using UnityEngine;
using FrontierSingletons;
using System.Collections.Generic;

public abstract class Controller : MonoBehaviour
{
    protected bool running = false;

    protected void Start()
    {
        var instance = LevelLoaderSingleton.Instance;
        if (instance.LevelReadyToRun())
            InitializeController();
    }

    protected virtual void OnEnable()
    {
        SubscribeToSingletonsEvents();
        AddComponents();
        SubscribeToComponentsEvents();
    }

    protected virtual void OnDisable()
    {
        UnsubscribeFromComponentsEvents();
        UnsubscribeFromSingletonsEvents();
    }

    protected void Update()
    {
        if (!running) return;
        RunController();
    }


    protected virtual void SubscribeToSingletonsEvents()
    {
        LevelLoaderSingleton.Instance.OnLevelInitialized += InitializeController;
    }

    protected virtual void UnsubscribeFromSingletonsEvents()
    {
        var instance = LevelLoaderSingleton.Instance;
        if (instance)
            instance.OnLevelInitialized -= InitializeController;
    }

    protected virtual void InitializeController()
    {
        InitializeComponents();
        running = true;
    }

    public abstract void InitializeComponents();
    public abstract void AddComponents();
    protected abstract void RunController();
    public virtual void SubscribeToComponentsEvents() { }
    public virtual void UnsubscribeFromComponentsEvents() { }
}
