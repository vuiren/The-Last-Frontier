using System;
using Base;
using Services;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private IActorsService _actorsService;
    [Inject]
    public void Construct(IActorsService actorsService)
    {
        _actorsService = actorsService;
    }

    private void Start()
    {
        var actors = FindObjectsOfType<Actor>();
        for (var index = 0; index < actors.Length; index++)
        {
            var actor = actors[index];
            _actorsService.RegisterActor(index, actor);
        }
    }
}