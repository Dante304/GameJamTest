using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithCamera : MonoBehaviour
{
    public Transform camera;

    void Update()
    {
        this.transform.position = new Vector3(camera.position.x, camera.position.y,0);
    }
}
