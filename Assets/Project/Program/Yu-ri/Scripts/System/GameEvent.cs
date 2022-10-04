using System;
public class GameEvent
{
    public Action SetBatteryImage;
    public Action ChangeBatteryAmount;
    public Action ZeroTimeLimit;
    public Action SetResult;
    public Action playerCaptured;
    public Action LifeDecrease;
    public Action SetCrackImage;
    public Action NoLife;
    public Action GameOver;
    public Action SetGameOver;
}