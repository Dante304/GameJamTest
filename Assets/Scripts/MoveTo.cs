using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;
            gameObject.transform.position = pz;
        }
    }
}
