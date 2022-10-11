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
    List<IFadeUpdateSystem> _fadeUpdateSystemList;

    void Awake()
    {
        _gameEvent = new GameEvent();
        _preUpdateSystemList = new List<IPreUpdateSystem>();
        _onUpdateSystemList = new List<IOnUpdateSystem>();
        _fadeUpdateSystemList = new List<IFadeUpdateSystem>();

        _systemList = new List<BaseSystem>()
        {
            new GameRule(),
            new MoveSystem(),
            new AnimationSystem(),
            new WarpSystem(),
            new FadeSystem(),
            new InputSystem(),
        };

        foreach (BaseSystem system in _systemList)
        {
            system.Init(_gameState, _gameEvent);
            system.SetEvent();
            if (system is IPreUpdateSystem) _preUpdateSystemList.Add(system as IPreUpdateSystem);
            if (system is IOnUpdateSystem) _onUpdateSystemList.Add(system as IOnUpdateSystem);
            if (system is IFadeUpdateSystem) _fadeUpdateSystemList.Add(system as IFadeUpdateSystem);
        }
    }
    void Start()
    {

    }

    void Update()
    {
        if (isFade())
        {
            FadeUpdate();
            return;
        }
        foreach (var system in _preUpdateSystemList) system.PreUpdate();
        foreach (var system in _onUpdateSystemList) system.OnUpdate();
    }
    void FadeUpdate()
    {
        foreach (var system in _fadeUpdateSystemList) system.FadeUpdate();
    }
    bool isFade()
    {
        return _gameState.isFadeOut || _gameState.isFadeIn;
    }
}
