using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plant : MonoBehaviour
{
    // vùng được đào đất và tile mới khi đào
    public Tilemap tilemap; // Kéo và thả Tilemap vào đây
    public TileBase newTile; // Tile mới bạn muốn đặt


    // player vô đó mới đào đc
    private bool canDig = false;
    private bool canPlant = false;

    // trồng cây 
    public GameObject treePrefab;


    // Mảng boolean để lưu trạng thái đào của từng ô đất
    private bool[] dugTiles;


    private void Start()
    {
        // Khởi tạo mảng dugTiles với kích thước tương ứng với số ô trên Tilemap
        dugTiles = new bool[tilemap.cellBounds.size.x * tilemap.cellBounds.size.y];
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canDig)
        {
            Dig();

        }

        if (Input.GetKeyDown(KeyCode.Z) && canPlant && canDig)
        {
            PlantFL();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dig"))
        {
            canDig = true; // Cho phép đào đất khi vào vùng đất
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Dig"))
        {
            canDig = false; // Ngăn chặn đào đất khi ra khỏi vùng đất
        }
    }

    private void Dig()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = tilemap.WorldToCell(mousePosition);

        int index = GetTileIndex(cellPosition);

        if (index != -1 && !dugTiles[index])
        {
            // Đào đất và đánh dấu ô đã đào
            tilemap.SetTile(cellPosition, newTile);
            dugTiles[index] = true;
            canPlant = true;
        }

    }

    private void PlantFL()
    {
        if (canPlant)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);

            int index = GetTileIndex(cellPosition);

            if (index != -1 && dugTiles[index])
            {
                // Trồng cây tại ô đã đào
                GameObject treeInstance = Instantiate(treePrefab, tilemap.GetCellCenterWorld(cellPosition), Quaternion.identity);
            }
        }

    }

    private int GetTileIndex(Vector3Int cellPosition)
    {
        int cellX = cellPosition.x - tilemap.cellBounds.x;
        int cellY = cellPosition.y - tilemap.cellBounds.y;

        if (cellX >= 0 && cellX < tilemap.cellBounds.size.x && cellY >= 0 && cellY < tilemap.cellBounds.size.y)
        {
            return cellY * tilemap.cellBounds.size.x + cellX;
        }

        return -1; // Trả về -1 nếu ô nằm ngoài biên của Tilemap
    }

}

