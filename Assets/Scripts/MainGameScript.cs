using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.XR.WSA;
using static Constants;

public class MainGameScript : MonoBehaviour
{
    public BuildingManager BuildingManager;
    public ResourceManager ResourceManager;
    public UIManager UIManager;
    public Spawner Spawner;
    //public List<Building> Buildings;
    public int CurrentPlayers = 1;

    private decimal[] _playersResources;
    private CurrentPlayerAction _currentPlayerAction = CurrentPlayerAction.None;
    private GameObject _holdingObject = null;
    private Grid _grid;
    private Tilemap[] _tilemapGround;
    //private GameObject[,] _buildingsMap;
    private GameObject _selectedBuilding;
    private BuildingType _buildingType;
    private int[] _myBuildings;
    //private Dictionary<Vector3Int, GameObject> _buildingsDict = new Dictionary<Vector3Int, GameObject>();
    //private Dictionary<BuildingType, BuildingMonoBehaviour> _buildingsDefinitions;

    void Start()
    {
        _myBuildings = new int[Enum.GetValues(typeof(BuildingType)).Length];
        _playersResources = new decimal[8];

        _grid = FindObjectOfType<Grid>();
        _tilemapGround = _grid.GetComponentsInChildren<Tilemap>();
        //_buildingsMap = new GameObject[_tilemapGround[0].size.x + 1, _tilemapGround[0].size.y + 1];
    }

    void Update()
    {
        CheckIfBuildingSelectNeeded();

        switch (_currentPlayerAction)
        {
            case CurrentPlayerAction.None:
                HandleNoActionUpdate();
                break;
            case CurrentPlayerAction.Building:
                UpdateHoldObject();
                break;
            case CurrentPlayerAction.SelectedBuilding:
                HandleSelectedBuildingAction();
                break;
            default:
                break;
        }
    }


    public void StartBuilding(BuildingType buildingType)
    {
        SpawnBuilding(buildingType);
        _currentPlayerAction = CurrentPlayerAction.Building;
    }

    private void SpawnBuilding(BuildingType buildingType)
    {
        _buildingType = buildingType;

        var spawner = FindObjectOfType<Spawner>();
        if (spawner != null)
        {
            _holdingObject = spawner.SpawnObject(buildingType, Input.mousePosition);
            _holdingObject.name += "|holding";
            _holdingObject.layer = 10;
        }
    }

    private void UpdateHoldObject()
    {
        if (_holdingObject == null) return;

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.x = Mathf.Floor(mousePos.x) + 0.5f;
        mousePos.y = Mathf.Floor(mousePos.y) + 0.25f;
        mousePos.z = _holdingObject.transform.position.z;
        var rb = _holdingObject.GetComponent<Rigidbody2D>();
        rb.transform.position = mousePos; // new Vector3(mousePos.x, mousePos.y, _holdingObject.transform.position.z);


        //_grid.cellGap = new Vector3(0.05f, 0.05f, 0);
        //_grid.cellSize = new Vector3(0.9f, 0.9f, 0);

        /*var cell = _grid.WorldToCell(mousePos);
        var tileMap = _grid.GetComponentInChildren<Tilemap>();*/

        /*var collider = _holdingObject.GetComponent<BoxCollider2D>();
        var results = new RaycastHit2D[1];
        collider.Raycast(mousePos, results);
        if (results.Length > 0)
        {
            var cellPosition = _grid.WorldToCell(results[0].point);
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    var tilePos = cellPosition + new Vector3Int(x, y, 0);
                    _tilemapGround[0].SetTileFlags(tilePos, TileFlags.None);
                    _tilemapGround[0].SetColor(tilePos, Color.blue);
                }
            }
        }*/

        var building = _holdingObject.GetComponent<Building>();
        var enoughResources = BuildingManager.HaveEnoughResources(0, building);

        if (!building._isValidPlacement || !enoughResources)
        {
            /*tileMap.SetTileFlags(cell, TileFlags.None);
            tileMap.SetColor(cell, Color.red);*/
            _holdingObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
        else
        {
            /*tileMap.SetTileFlags(cell, TileFlags.None);
            tileMap.SetColor(cell, Color.green);*/
            _holdingObject.GetComponentInChildren<SpriteRenderer>().color = Color.green;
        }

        if (_currentPlayerAction == CurrentPlayerAction.Building && building._isValidPlacement && enoughResources && Input.GetMouseButtonDown(0))
        {
            if (BuildingManager.PlaceBuilding(0, building, mousePos))
            {
                Destroy(_holdingObject);
                _currentPlayerAction = CurrentPlayerAction.None;
            }

            // spawn new

            //_holdingObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            //_holdingObject.name = _holdingObject.name.Substring(0, _holdingObject.name.IndexOf("|"));
            //Destroy(_holdingObject.GetComponent<Collider>());
            //_currentPlayerAction = CurrentPlayerAction.None;
            
            //var cellCoords = _grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            //var tile = _tilemapGround[0].GetTile(cellCoords);

            //Debug.Log($"buildings map size = {_buildingsMap.Length}");
            //Debug.Log($"placing building at coords: {cellCoords.x}, {cellCoords.y}");
            //_buildingsMap[cellCoords.x, cellCoords.y] = _holdingObject;
        }

        if (_currentPlayerAction == CurrentPlayerAction.Building && _holdingObject != null && Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(_holdingObject);
            _holdingObject = null;
            _currentPlayerAction = CurrentPlayerAction.None;
        }
    }

    private void HandleNoActionUpdate()
    {
    }

    private void HandleSelectedBuildingAction()
    {
        if (_selectedBuilding == null)
            return;

        _selectedBuilding.GetComponentInChildren<SpriteRenderer>().color = Color.blue;

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            BuildingManager.RemoveBuilding(0, _selectedBuilding.GetComponentInChildren<Building>());
        }
    }

    private void CheckIfBuildingSelectNeeded()
    {
        if (_currentPlayerAction == CurrentPlayerAction.Building)
            return;

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.x = Mathf.Floor(mousePos.x) + 0.5f;
            mousePos.y = Mathf.Floor(mousePos.y) + 0.25f;

            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (BuildingManager.IsBuilding(_selectedBuilding))
            {
                _selectedBuilding.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                _currentPlayerAction = CurrentPlayerAction.None;
            }

            _selectedBuilding = hit.collider.gameObject;
            if (BuildingManager.IsBuilding(_selectedBuilding))
            {
                _currentPlayerAction = CurrentPlayerAction.SelectedBuilding;
            }

        }
    }
}
