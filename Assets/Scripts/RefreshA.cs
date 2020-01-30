using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshA : MonoBehaviour
{
    private AstarPath astarPath;
    private void Start()
    {
       astarPath = GetComponent<AstarPath>();
    }

    void Update()
    {
        astarPath.Scan();
    }
}
