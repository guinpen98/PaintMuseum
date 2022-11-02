using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoveComponent
{
    public Vector2 inputMove;
    public float verticalVelocity;
    public bool isGroundedPrev;
    public float speed = 3;
    public float jumpSpeed = 7;
    public float gravity = 15;
    public float fallSpeed = 10;
    public float initFallSpeed = 2;
}
