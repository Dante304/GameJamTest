using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using static Constants;

public class Building : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup _healthBar;
    [SerializeField]
    private CanvasGroup _selectionBox;
    [SerializeField]
    private HitPointsStat _hitPoints;

    private BuildingManager _buildingManager;

    public bool _isValidPlacement = true;
    public bool _isActive = false;
    public ResourceType ProducedResource;
    public int ResourcePerTick;
    public BuildingType BuildingType;
    
    public int[] BuildCost;

    private bool _isSelected = false;

    public bool IsMoving { get; set; }

    public int OwningPlayer { get; set; }

    public HitPointsStat HitPoints { get; set; }

    private void Start()
    {
        _buildingManager = FindObjectOfType<BuildingManager>();
    }

    private void OnMouseEnter()
    {
        if (IsMoving)
            return;

        if (!_isSelected)
            _selectionBox.alpha = 1;
    }

    private void OnMouseExit()
    {
        if (IsMoving)
            return;

        if (!_isSelected)
            _selectionBox.alpha = 0;
    }

    private void Update()
    {
        if (IsMoving)
            return;

        if (_isSelected && Input.GetKeyDown(KeyCode.Alpha1))
        {
            _buildingManager.DealDamage(this, 20);
        }

        if (_isSelected && Input.GetKeyDown(KeyCode.Alpha2))
        {
            _buildingManager.HealDamage(this, 20);
        }

        if (Mathf.Max(HitPoints.GetLerpHitPoints(), 0f) <= 0f)
            _buildingManager.RemoveBuilding(OwningPlayer, this, false);
    }

    public void Select()
    {
        if (IsMoving)
            return;

        _isSelected = true;
        _healthBar.alpha = 1;
        _selectionBox.alpha = 1;
        GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
    }

    public void Deselect()
    {
        if (IsMoving)
            return;

        _isSelected = false;
        _healthBar.alpha = 0;
        _selectionBox.alpha = 0;
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
}
