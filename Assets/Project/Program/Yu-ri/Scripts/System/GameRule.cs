using UnityEngine;
public class GameRule : BaseSystem
{
    public override void SetEvent()
    {
        _gameEvent.SetWarp += SetFadeOut;
        _gameEvent.FinishFadeOut += SetFadeIn;
        _gameEvent.FinishFadeOut += Warp;
        _gameEvent.FinishFadeIn += FinishWarp;
    }
    void SetFadeOut()
    {
        _gameEvent.SetFadeOut.Invoke();
    }
    void SetFadeIn()
    {
        _gameEvent.SetFadeIn.Invoke();
    }
    void Warp()
    {
        _gameEvent.Warp.Invoke();
    }
    void FinishWarp()
    {
        _gameEvent.FinishWarp.Invoke();
    }
}
