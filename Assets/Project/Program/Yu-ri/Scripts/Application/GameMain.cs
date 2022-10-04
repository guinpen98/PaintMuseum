using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField] GameState _gameState;
    GameEvent _gameEvent;

    List<BaseSystem> _systemList;
    List<IPreUpdateSystem> _preUpdateSystemList;
    List<IOnUpdateSystem> _onUpdateSystemList;

    void Awake()
    {
        _gameEvent = new GameEvent();
        _preUpdateSystemList = new List<IPreUpdateSystem>();
        _onUpdateSystemList = new List<IOnUpdateSystem>();

        _systemList = new List<BaseSystem>()
        {
            new GameRule(),
            new MoveSystem(),
            new AnimationSystem(),
        };

        foreach (BaseSystem system in _systemList)
        {
            system.Init(_gameState, _gameEvent);
            system.SetEvent();
            if (system is IPreUpdateSystem) _preUpdateSystemList.Add(system as IPreUpdateSystem);
            if (system is IOnUpdateSystem) _onUpdateSystemList.Add(system as IOnUpdateSystem);
        }
    }
    void Start()
    {

    }

    void Update()
    {
        if (isNotPlay()) return;
        foreach (var system in _preUpdateSystemList) system.PreUpdate();
        if (isNotPlay()) return;
        foreach (var system in _onUpdateSystemList) system.OnUpdate();
    }
    bool isNotPlay()
    {
        return false;
    }
}
