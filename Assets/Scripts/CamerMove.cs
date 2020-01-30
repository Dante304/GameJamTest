using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerMove : MonoBehaviour
{
    public int side;
    public int enter;
    public Transform camera;
    public float movementSpeed;

    void OnMouseEnter()
    {
        enter = side;
        Debug.Log("Enter");
    }

    
    void OnMouseExit()
    {
        enter = 0;
        Debug.Log("Exit");
    }
   

    private void Update()
    {
        switch (enter)
        {
            case 0:
                break;
            case 1:
                camera.position = camera.position + new Vector3(0, 1 * movementSpeed * Time.deltaTime, 0);
                break;
            case 2:
                camera.position = camera.position + new Vector3(0, -1 * movementSpeed * Time.deltaTime, 0);
                break;
            case 3:
                camera.position = camera.position + new Vector3(-1 * movementSpeed * Time.deltaTime,0, 0);
                break;
            case 4:
                camera.position = camera.position + new Vector3(1 * movementSpeed * Time.deltaTime, 0, 0);
                break;
            default:
                break;
        }
    }


}
