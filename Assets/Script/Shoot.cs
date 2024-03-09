using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject blast;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(blast, transform.GetChild(0).position, transform.rotation);
        }
    }
}
