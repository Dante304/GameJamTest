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



    public void AttackOrder()
    {
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
