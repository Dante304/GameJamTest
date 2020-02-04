using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerMove : MonoBehaviour
{

    //STARY KOD
    public int side;
    public int enter;
    private Transform cameraTransform;
    public float movementSpeed;

    private void Start()
    {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

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

    //STARY KOD
    private void Update()
    {
        switch (enter)
        {
            case 0:
                break;
            case 1:
                cameraTransform.position = cameraTransform.position + new Vector3(0, 1 * movementSpeed * Time.deltaTime, 0);
                break;
            case 2:
                cameraTransform.position = cameraTransform.position + new Vector3(0, -1 * movementSpeed * Time.deltaTime, 0);
                break;
            case 3:
                cameraTransform.position = cameraTransform.position + new Vector3(-1 * movementSpeed * Time.deltaTime,0, 0);
                break;
            case 4:
                cameraTransform.position = cameraTransform.position + new Vector3(1 * movementSpeed * Time.deltaTime, 0, 0);
                break;
            case 5:
                cameraTransform.position = cameraTransform.position + new Vector3(1 * movementSpeed * Time.deltaTime, 1 * movementSpeed * Time.deltaTime, 0);
                break;
            case 6:
                cameraTransform.position = cameraTransform.position + new Vector3(-1 * movementSpeed * Time.deltaTime, 1 * movementSpeed * Time.deltaTime, 0);
                break;
            case 7:
                cameraTransform.position = cameraTransform.position + new Vector3(-1 * movementSpeed * Time.deltaTime, -1 * movementSpeed * Time.deltaTime, 0);
                break;
            case 8:
                cameraTransform.position = cameraTransform.position + new Vector3(1 * movementSpeed * Time.deltaTime, -1 * movementSpeed * Time.deltaTime, 0);
                break;
            default:
                break;
        }
    }

    //STARY KOD
}
