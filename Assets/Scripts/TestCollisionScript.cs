using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var bounds = GetComponent<Collider2D>().bounds;
        // Expand the bounds along the Z axis
        bounds.Expand(Vector3.forward * 1000);
        var guo = new GraphUpdateObject(bounds);
        // change some settings on the object
        AstarPath.active.UpdateGraphs(guo);
    }
}
