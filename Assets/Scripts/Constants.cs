using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public enum CurrentPlayerAction
    {
        None = 0,
        Building = 1,
        SelectedBuilding
    }

    public enum BuildingType
    {
        Gold = 0,
        Wood = 1,
        Iron = 2,
        Stone = 3
    }

    public enum ResourceType
    {
        Gold = 0,
        Wood = 1,
        Iron = 2,
        Stone = 3
    }
}
