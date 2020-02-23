using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMoveOnEnter : MonoBehaviour
{
    private AILerp aIPath;
    public GameObject flag;
    private void Start()
    {
        aIPath = GetComponent<AILerp>();
    }

    public void Update()
    {
        flag = GetComponent<AIDestinationSetter>().flag;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == flag)
        {
            aIPath.canMove = false;
        }
       
    }
}
