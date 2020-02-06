using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Debug = UnityEngine.Debug;

public class ColliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "ground")
            GetComponent<Building>()._isValidPlacement = false;

        /*else if (col.tag.ToLower() == "ground")
        {
            var tilemap = col.GetComponentInParent<Tilemap>();
            //var grid = col.GetComponentInParent<Grid>();
            var cellPos = tilemap.WorldToCell(transform.position);
            //grid.WorldToCell()
            tilemap.SetTileFlags(cellPos, TileFlags.None);
            tilemap.SetColor(cellPos, Color.red);
            Debug.Log($"{name} collision with {col.name}, cellPos: {cellPos}");
        }*/
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.name != "Tilemap_Ground")
        {
            GetComponent<Building>()._isValidPlacement = false;
        }

        /*if (col.tag.ToLower() == "ground")
        {

            var tilemap = col.GetComponentInParent<Tilemap>();

            var colliders = new Collider2D[10];
            var collidersHit = GetComponent<Collider2D>().GetContacts(colliders);
            Debug.Log($"collisions: {colliders.Length} (collidersHit: {collidersHit})");
            for (int i = 0; i < collidersHit; i++)
            {
                var cellPos = tilemap.WorldToCell(colliders[i].transform.position);
                tilemap.SetTileFlags(cellPos, TileFlags.None);
                tilemap.SetColor(cellPos, Color.red);
                Debug.Log($"{name} collision {i} with {col.name}, cellPos: {cellPos}");
            }
        }*/
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag != "ground")
            GetComponent<Building>()._isValidPlacement = true;

        /*if (col.tag == "ground")
        {
            var tilemap = col.GetComponentInParent<Tilemap>();
            //var grid = col.GetComponentInParent<Grid>();
            var cellPos = tilemap.WorldToCell(col.transform.position);
            //grid.WorldToCell()
            tilemap.SetTileFlags(cellPos, TileFlags.None);
            tilemap.SetColor(cellPos, Color.white);
        }*/
    }
}
