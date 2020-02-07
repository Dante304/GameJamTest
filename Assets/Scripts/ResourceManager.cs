using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Constants;

public class ResourceManager : MonoBehaviour
{
    public MainGameScript MainGameScript;
    public UIManager UIManager;
    public BuildingManager BuildingManager;
    public int[] StartingResources;

    private Spawner _spawner;
    private Dictionary<int, decimal[]> _playersResources;

    // Start is called before the first frame update
    void Start()
    {
        _playersResources = new Dictionary<int, decimal[]>();

        for (int i = 0; i < MainGameScript.CurrentPlayers; i++)
        {
            _playersResources.Add(i, StartingResources.Select(x => (decimal)x).ToArray());
        }

        _spawner = FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        UpdateResources();
    }

    public decimal[] GetPlayerResources(int playerId)
    {
        if (!_playersResources.ContainsKey(playerId))
            _playersResources.Add(playerId, new decimal[Enum.GetValues(typeof(ResourceType)).Length]);

        return _playersResources[playerId];
    }

    public bool SubtractResource(int playerId, ResourceType resource, decimal amount)
    {
        if (!CanSubtractResource(playerId, resource, amount))
            return false;

        _playersResources[playerId][(int)resource] -= amount;
        return true;
    }

    public bool CanSubtractResource(int playerId, ResourceType resource, decimal amount)
    {
        if (!_playersResources.ContainsKey(playerId))
        {
            _playersResources.Add(playerId, new decimal[Enum.GetValues(typeof(ResourceType)).Length]);
            return false;
        }

        if (_playersResources[playerId][(int)resource] < amount)
        {
            return false;
        }

        return true;
    }

    public bool CanAddResource(int playerId, ResourceType resource, decimal amount)
    {
        if (!_playersResources.ContainsKey(playerId))
            _playersResources.Add(playerId, new decimal[Enum.GetValues(typeof(ResourceType)).Length]);

        // todo: check if warehouse (if any?) is full
        //if (_playersResources[playerId][(int)resource] + amount > maxAmount)
        //{
        //    return false;
        //}

        return true;
    }

    public bool AddResource(int playerId, ResourceType resource, decimal amount)
    {
        if (!CanAddResource(playerId, resource, amount))
            return false;

        _playersResources[playerId][(int)resource] += amount; 
        return true;
    }

    private void UpdateResources()
    {
        var resources = new List<ResourceInfo>();
        for (int playerId = 0; playerId < MainGameScript.CurrentPlayers; playerId++)
        {
            var playerBuildings = BuildingManager.GetBuildingsForPlayer(playerId);
            for (int id = 0; id < playerBuildings.Length; id++)
            {
                if (_spawner.Buildings.Count < id + 1 || playerBuildings.Length < id + 1)
                    continue;

                var building = _spawner.Buildings[id].GetComponent<Building>();
                var buildingProduction = GetResourcesForBuilding(building);
                var resourcesProduced = buildingProduction * playerBuildings[id] * (decimal)Time.deltaTime;
                var resourceType = building.ProducedResource;

                if (AddResource(playerId, resourceType, resourcesProduced))
                    resources.Add(new ResourceInfo { ResourceType = resourceType, Amount = _playersResources[playerId][(int)resourceType], Name = resourceType.ToString(), BuildingsAmount = playerBuildings[id], PerTick = resourcesProduced, PlayerId = playerId });
            }
        }

        UIManager.UpdateResources(resources);
    }

    private decimal GetResourcesForBuilding(Building building)
    {
        return building.ResourcePerTick;
    }
}
