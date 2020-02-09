using UnityEngine;
using static Constants;

public class ButtonHandler : MonoBehaviour
{
    public BuildingType BuildingType;

    public void Spawn()
    {
        var mainGameScript = FindObjectOfType<MainGameScript>();
        if (mainGameScript != null)
            mainGameScript.StartBuilding(BuildingType);
    }
}
