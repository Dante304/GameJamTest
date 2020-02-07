using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class Resource : MonoBehaviour
{
    public ResourceType ResourceType { get; set; }

    public decimal Amount { get; set; }

    public string Name { get; set; }

    public int BuildingsAmount { get; set; }
    
    public decimal PerTick { get; set; }
}
