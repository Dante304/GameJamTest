using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithCamera : MonoBehaviour
{
    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    void Update()
    {
        this.transform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y,0);
    }
}
