using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class BuildingManager : MonoBehaviour
{
    public ResourceManager ResourceManager;

    private Dictionary<int, int[]> _playersBuildings;
    private Grid _grid;

    // Start is called before the first frame update
    void Start()
    {
        _playersBuildings = new Dictionary<int, int[]>();
        _grid = FindObjectOfType<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsBuilding(GameObject gameObject)
    {
        return gameObject != null && gameObject.TryGetComponent(out Building building);
    }

    public bool PlaceBuilding(int playerId, Building building, Vector3 position)
    {
        try
        {
            var spawner = GetComponent<Spawner>();
            if (spawner != null)
            {
                //var playerResources = ResourceManager.GetPlayerResources(playerId);
                if (!HaveEnoughResources(playerId, building))
                {
                    //building._isValidPlacement = false;
                    return false;
                }

                if (!SubtractResources(playerId, building))
                {
                    //building._isValidPlacement = false;
                    return false;
                }

                var tilePos = _grid.WorldToCell(position);
                var spawnedBuilding = spawner.SpawnObject(building.BuildingType, position);
                spawnedBuilding.layer = 10;
                var newBuilding = spawnedBuilding.GetComponent<Building>();
                newBuilding.name += $"_{_playersBuildings[playerId][(int)newBuilding.BuildingType] + 1}";
                newBuilding._isActive = true;
                newBuilding.IsMoving = false;
                if (!_playersBuildings.ContainsKey(playerId))
                    _playersBuildings.Add(playerId, new int[Enum.GetValues(typeof(BuildingType)).Length]);

                _playersBuildings[playerId][(int)newBuilding.BuildingType]++;
                Destroy(spawnedBuilding.GetComponent<ColliderScript>());
            }
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
            building._isValidPlacement = false;
            return false;
        }

        return true;
    }

    public bool RemoveBuilding(int playerId, Building building)
    {
        if (building == null)
            return false;

        if (!_playersBuildings.ContainsKey(playerId))
        {
            _playersBuildings.Add(playerId, new int[Enum.GetValues(typeof(BuildingType)).Length]);
            return false;
        }

        if (_playersBuildings[playerId].Length < (int)building.BuildingType + 1)
            return false;

        if (_playersBuildings[playerId][(int)building.BuildingType] == 0)
            return false;

        _playersBuildings[playerId][(int)building.BuildingType]--;
        for (int i = 0; i < building.BuildCost.Length; i++)
        {
            ResourceManager.AddResource(playerId, (ResourceType)i, building.BuildCost[i] * 0.5m);
        }
        
        Destroy(building.gameObject);
        return true;
    }

    public int[] GetBuildingsForPlayer(int playerId)
    {
        if (!_playersBuildings.ContainsKey(playerId))
            _playersBuildings.Add(playerId, new int[Enum.GetValues(typeof(BuildingType)).Length]);

        return _playersBuildings[playerId];
    }

    public bool HaveEnoughResources(int playerId, Building building)
    {
        for (int i = 0; i < building.BuildCost.Length; i++)
        {
            if (!ResourceManager.CanSubtractResource(playerId, (ResourceType)i, building.BuildCost[i]))
            {
                return false;
            }
        }

        return true;
    }

    private bool SubtractResources(int playerId, Building building)
    {
        for (int i = 0; i < building.BuildCost.Length; i++)
        {
            if (!ResourceManager.SubtractResource(playerId, (ResourceType)i, building.BuildCost[i]))
            {
                return false;
            }
        }

        return true;
    }
}
