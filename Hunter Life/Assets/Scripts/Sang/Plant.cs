using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class Plant : MonoBehaviour
{
    // vùng tile cần thực hiện
    public Tilemap tilemap;
    // đất mới
    public TileBase newTile;
    // tạo cây
    public GameObject treePrefab;

    // đóng or mở ô có thể đào và trồng
    private bool canDig = false;
    private bool canPlant = false;

    // xác định được ô nào đào rồi và ô nào được trồng cây rồi
    private bool[] dugTiles;
    private bool[] plantedTrees;


    private void Start()
    {
        // tạo 1 mảng lấy vị trí của ô đất đã đào và ô đã trồng cây
        dugTiles = new bool[tilemap.cellBounds.size.x * tilemap.cellBounds.size.y];
        plantedTrees = new bool[tilemap.cellBounds.size.x * tilemap.cellBounds.size.y];

    }

    private void Update()
    {
        // đào đất
        if (Input.GetMouseButtonDown(0) && canDig)
        {
            Dig();
        }

        // trồng cây
        if (Input.GetKeyDown(KeyCode.Z) && canPlant && canDig)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);

            if (tilemap.GetTile(cellPosition) == newTile)
            {
                if (!IsTilePlanted(cellPosition))
                {
                    PlantFL();
                }
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dig"))
        {
            canDig = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Dig"))
        {
            canDig = false;
        }
    }

    // hàm đào đất
    private void Dig()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = tilemap.WorldToCell(mousePosition);

        int index = GetTileIndex(cellPosition);

        if (index != -1 && !dugTiles[index])
        {
            tilemap.SetTile(cellPosition, newTile);
            dugTiles[index] = true;
            canPlant = true;
        }
    }

    // hàm trồng cây
    private void PlantFL()
    {
        if (canPlant)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);

            int index = GetTileIndex(cellPosition);

            if (index != -1 && dugTiles[index] && !plantedTrees[index])
            {
                // Kiểm tra ô đã trồng cây chưa
                if (!IsTilePlanted(cellPosition) && !TreeExistsAtCell(cellPosition))
                {
                    // Trồng cây tại ô đã đào
                    Instantiate(treePrefab, tilemap.GetCellCenterWorld(cellPosition), Quaternion.identity);
                    
                }
            }
        }
    }


    // xác định vị trí của ô trong tilemap
    private int GetTileIndex(Vector3Int cellPosition)
    {
        int cellX = cellPosition.x - tilemap.cellBounds.x;
        int cellY = cellPosition.y - tilemap.cellBounds.y;

        if (cellX >= 0 && cellX < tilemap.cellBounds.size.x && cellY >= 0 && cellY < tilemap.cellBounds.size.y)
        {
            return cellY * tilemap.cellBounds.size.x + cellX;
        }

        return -1;
    }

    // Kiểm tra ô đã trồng cây chưa
    private bool IsTilePlanted(Vector3Int cellPosition)
    {
        int index = GetTileIndex(cellPosition);
        return index != -1 && plantedTrees[index];
    }

    private bool TreeExistsAtCell(Vector3Int cellPosition)
    {
        Collider2D[] colliders = Physics2D.OverlapPointAll(tilemap.GetCellCenterWorld(cellPosition));
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("FLBlue"))
            {
                return true;
            }
        }
        return false;
    }

}