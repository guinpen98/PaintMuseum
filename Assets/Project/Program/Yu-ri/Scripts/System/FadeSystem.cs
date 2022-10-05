using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeSystem : BaseSystem, IFadeUpdateSystem
{
    public override void SetEvent()
    {
        _gameEvent.SetFadeIn += SetFadeIn;
        _gameEvent.SetFadeOut += SetFadeOut;
    }
    public void FadeUpdate()
    {
        if (_gameState.isFadeOut) FadeOut();
        else if(_gameState.isFadeIn) FadeIn();
    }
    void FadeOut()
    {
        Image fadeImage = _gameState.FadePanel.GetComponent<Image>();
        Color color = fadeImage.color;
        color.a += 0.01f;
        fadeImage.color = color;
        if (color.a < 1) return;
        _gameEvent.FinishFadeOut.Invoke();
        _gameState.isFadeOut = false;
    }
    void FadeIn()
    {
        Image fadeImage = _gameState.FadePanel.GetComponent<Image>();
        Color color = fadeImage.color;
        color.a -= 0.01f;
        fadeImage.color = color;
        if (color.a > 0) return;
        _gameState.isFadeIn = false;
    }
    void SetFadeOut()
    {
        _gameState.isFadeOut = true;
    }
    void SetFadeIn()
    {
        _gameState.isFadeIn = true;
    }
}
