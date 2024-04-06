using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public GameObject parent;
    public void Death()
    {
        Destroy(parent);
    }
}
