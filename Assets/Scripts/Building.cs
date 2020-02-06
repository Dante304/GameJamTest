using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static Constants;

public class Building : MonoBehaviour
{
    public bool _isValidPlacement = true;
    public bool _isActive = false;
    public ResourceType ProducedResource;
    public int ResourcePerTick;
    public BuildingType BuildingType;

    public int[] BuildCost;
}
