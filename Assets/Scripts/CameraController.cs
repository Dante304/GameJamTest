using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed;
    public float movementSpeed;
    public float panBorderThickness;
    public enum Players { Player1, Player2 };
    public Players cameraOnPlayer;
    private Vector3 pos;

    private void Start()
    {
        CameraPositionOnStart();
    }


    private void Update()
    {
        CameraMove();
        ZoomInOut();
    }

    private void CameraPositionOnStart()
    {
        switch (cameraOnPlayer)
        {
            case Players.Player1:
                var tempPosition1 = GameObject.FindGameObjectWithTag("Player1").transform.position;
                this.transform.position = new Vector3(tempPosition1.x, tempPosition1.y, this.transform.position.z);
                break;
            case Players.Player2:
                var tempPosition2 = GameObject.FindGameObjectWithTag("Player2").transform.position;
                this.transform.position = new Vector3(tempPosition2.x, tempPosition2.y, this.transform.position.z);
                break;
            default:
                var tempPositionDefault = GameObject.FindGameObjectWithTag("Player1").transform.position;
                this.transform.position = new Vector3(tempPositionDefault.x, tempPositionDefault.y, this.transform.position.z);
                break;
        }
    }

    private void CameraMove()
    {
        pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) //Up
        {
            pos = this.transform.position + new Vector3(0, 1 * movementSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) //Down
        {
            pos = this.transform.position + new Vector3(0, -1 * movementSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) //Left
        {
            pos = this.transform.position + new Vector3(-1 * movementSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) //Right
        {
            pos = this.transform.position + new Vector3(1 * movementSpeed * Time.deltaTime, 0, 0);
        }

        transform.position = pos;
    }


    private void ZoomInOut()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && GetComponent<Camera>().orthographicSize > 5) // Zoom In
        {
            GetComponent<Camera>().orthographicSize = GetComponent<Camera>().orthographicSize - 0.5f;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && GetComponent<Camera>().orthographicSize < 8) // Zoom Out
        {
            GetComponent<Camera>().orthographicSize = GetComponent<Camera>().orthographicSize + 0.5f;
        }
    }
}
