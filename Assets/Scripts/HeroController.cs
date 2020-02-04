using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    private void Start()
    {
        GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Target").transform;
    }
}
