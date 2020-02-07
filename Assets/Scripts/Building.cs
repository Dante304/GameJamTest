using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using static Constants;

public class Building : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup HealthBar;
    [SerializeField]
    private CanvasGroup SelectionBox;


    public bool _isValidPlacement = true;
    public bool _isActive = false;
    public ResourceType ProducedResource;
    public int ResourcePerTick;
    public BuildingType BuildingType;

    public int[] BuildCost;

    private bool _isSelected = false;

    public bool IsMoving { get; set; }

    public int HitPoints { get; set; }

    private void Start()
    {
    }

    private void OnMouseEnter()
    {
        if (IsMoving)
            return;

        if (!_isSelected)
            SelectionBox.alpha = 1;
    }

    private void OnMouseExit()
    {
        if (IsMoving)
            return;

        if (!_isSelected)
            SelectionBox.alpha = 0;
    }

    private void Update()
    {
        if (IsMoving)
            return;
    }

    public void Select()
    {
        if (IsMoving)
            return;

        _isSelected = true;
        HealthBar.alpha = 1;
        SelectionBox.alpha = 1;
        GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
    }

    public void Deselect()
    {
        if (IsMoving)
            return;

        _isSelected = false;
        HealthBar.alpha = 0;
        SelectionBox.alpha = 0;
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
}
