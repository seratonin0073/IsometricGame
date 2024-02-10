using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{

    public static readonly string[] staticDirection =
    {
        "StaticN", "StaticNE", "StaticE","StaticSE", "StaticS", "StaticSW","StaticW", "StaticNW"
    };

    public static readonly string[] runDirection =
    {
        "RunN", "RunNE", "RunE","RunSE", "RunS", "RunSW","RunW", "RunNW"
    };

    Animator anim;
    int lastDirection;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    public void SetDirection(Vector2 direction)
    {
        string[] directionArray = null;

        if (direction.magnitude < 0.01)
        {
            directionArray = staticDirection;
        }
        else
        {
            directionArray = runDirection;
            lastDirection = DirectionToIndex(direction);
        }
        anim.Play(directionArray[lastDirection]);
    }

    private int DirectionToIndex(Vector2 direction)
    {
        Vector2 norDir = direction.normalized;

        float step = 45;
        float offset = step / 2;

        float angel = Vector2.SignedAngle(Vector2.up, norDir);
        angel += offset;
        if(angel < 0)
        {
            angel += 360;
        }

        float stepCount = angel / step;
        return Mathf.FloorToInt(stepCount);
    }
}

enum StaticDirection
{
    StaticN, StaticNE, StaticE, StaticSE, StaticS, StaticSW, StaticW, StaticNW
}

enum RunDirection
{
    RunN, RunNE, RunE, RunSE, RunS, RunSW, RunW, RunNW
}