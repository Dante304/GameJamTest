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
    public Transform attackTarget;

    public GameObject[] targetsTab;
    public List<Transform> targetsPosition;

    public GameObject pointsToMove;
    public void AttackOrder()
    {
        targetsTab = GameObject.FindGameObjectsWithTag("MinionTarget");

        for (int i = 0; i < targetsTab.Length; i++)
        {
            targetsTab[i].transform.position = new Vector3(attackTarget.position.x + i,attackTarget.position.y + i, attackTarget.position.z);
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
}