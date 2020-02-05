using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshA : MonoBehaviour
{
    private AstarPath astarPath;
    private float actualTime;

    public float timeToRefresh;
    public bool refresh;

    private void Start()
    {
       astarPath = GetComponent<AstarPath>();
    }

    void Update()
    {
        actualTime += Time.deltaTime;
        if (actualTime > timeToRefresh && refresh)
        {
            astarPath.Scan();
        }

    }
}
