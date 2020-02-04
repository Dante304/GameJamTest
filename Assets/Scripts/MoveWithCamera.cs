using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithCamera : MonoBehaviour
{
    private Transform cameraTransform;
    //STARY KOD
    private void Start()
    {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }
    //STARY KOD
    void Update()
    {
        this.transform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y,0);
    }
}
