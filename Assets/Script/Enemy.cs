using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public Patrol patrol;
    public AIDestinationSetter destinator;
    public GameObject target;

    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.transform.position);

        if(distance < 3f)
        {
            patrol.enabled = false;
            destinator.enabled = true;
        }
        else
        {
            patrol.enabled = true;
            destinator.enabled = false;
        }
    }
}
