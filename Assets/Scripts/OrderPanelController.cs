using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderPanelController : MonoBehaviour
{
    public enum Orders { Attack, Stop, Defense };
    public Orders activeOrder;

    public Sprite attackSprite;
    public Sprite stopSprite;
    public Sprite defenseSprite;

    public Image activeStatus;

    public Transform target;

    public float maxX;
    public float maxY;
    public GameObject flag;
    public List<GameObject> listOfFlags;
    public void AttackOrder()
    {
        foreach (var item in listOfFlags)
        {
            Destroy(item);
        }
        listOfFlags.Clear();
        var lisOfUnits = GameObject.FindGameObjectsWithTag("Unit");
        foreach (var item in lisOfUnits)
        {
            item.GetComponent<AIDestinationSetter>().flag = PointAroundTarget(target.position);
            item.GetComponent<MinionController>().attackTarget = item.GetComponent<AIDestinationSetter>().flag.transform;

            item.GetComponent<AILerp>().canMove = true;
        }

        activeStatus.sprite = attackSprite;
        activeOrder = Orders.Attack;
    }

    public void StopOrder()
    {
        activeStatus.sprite = stopSprite;
        activeOrder = Orders.Stop;
    }

    public void DefenseOrder()
    {
        activeStatus.sprite = defenseSprite;
        activeOrder = Orders.Defense;
    }


    public GameObject PointAroundTarget(Vector3 targetPosition)
    {
        Debug.Log($@"Target position: {targetPosition}");

        targetPosition.x = targetPosition.x + Random.Range(-maxX, maxX);
        targetPosition.y = targetPosition.y + Random.Range(-maxY, maxY);
        var flagObject = Instantiate(flag, targetPosition, Quaternion.identity);
        listOfFlags.Add(flagObject);
        return flagObject;
    }
}