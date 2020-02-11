using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class Spawner : MonoBehaviour
{
    public List<GameObject> Buildings;
    public GameObject HpBarCanvas;

    public GameObject SpawnObject(BuildingType buildingType, Vector3 pos)
    {
        //var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ObjectToSpawn.transform.position.z);
        var position = new Vector3(pos.x, pos.y, 0);
        return Instantiate(Buildings[(int)buildingType], position, Quaternion.identity);
    }

    public GameObject SpawnHealthBar(Vector3 pos)
    {
        var position = new Vector3(pos.x, pos.y, 0);
        return Instantiate(HpBarCanvas, position, Quaternion.identity);
    }
}
