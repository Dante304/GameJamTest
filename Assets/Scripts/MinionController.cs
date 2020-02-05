using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        GetComponent<AIDestinationSetter>().target = target;
    }

}
