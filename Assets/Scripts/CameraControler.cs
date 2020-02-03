using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public float panSpeed;
    private Vector3 pos;
    void Update()
    {
        pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y = panSpeed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
