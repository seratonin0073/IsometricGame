using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath path;
    public SpriteRenderer sprite;


    void Update()
    {
        if(path.desiredVelocity.x >= 0.01) sprite.flipX = true;
        else if(path.desiredVelocity.x <= -0.01) sprite.flipX = false;
    }
}
