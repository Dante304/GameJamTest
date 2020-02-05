using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour
{
    public Transform attackTarget;
    public Transform defenseTarget;
    public OrderPanelController orderPanel;
    public OrderPanelController.Orders activeOrder;
    private AIPath aIPath;
    private AIDestinationSetter aIDestinationSetter;

    private void Start()
    {
        aIDestinationSetter = GetComponent<AIDestinationSetter>();
        aIPath = GetComponent<AIPath>();
    }

    private void Update()
    {
        activeOrder = orderPanel.activeOrder;

        switch (activeOrder)
        {
            case OrderPanelController.Orders.Attack:
                aIDestinationSetter.target = attackTarget;
                aIPath.canMove = true;
                break;
            case OrderPanelController.Orders.Stop:
                aIPath.canMove = false;
                break;
            case OrderPanelController.Orders.Defense:
                aIDestinationSetter.target = defenseTarget;
                aIPath.canMove = true;
                break;
            default:
                break;
        }

    }
}
