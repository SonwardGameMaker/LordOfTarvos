using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvGraphics : MonoBehaviour
{
    public List<GameObject> groundGraphicPrefabs = new List<GameObject>();
    public List<GameObject> environmantPrefabs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTerrain(TerrainType terrainType)
    {
        float cellSize = GetComponent<GridToMap>().cellSize;

        for (int x = 0; x < GetComponent<GridToMap>().wight; x++)
        {
            for (int y = 0; y < GetComponent<GridToMap>().heigth; y++)
            {
                Vector3 position = GetComponent<GridToMap>().CellNumToWorldPosition(x, y, transform.position.z);

                if (GetComponent<GridToMap>().grid._grid[x, y].status == NodeFill.Water)
                {
                    GetComponent<GridToMap>().grid._grid[x, y].unitIn = Instantiate(environmantPrefabs[2], position, transform.rotation);
                    GetComponent<GridToMap>().grid._grid[x, y].unitIn.transform.localScale = new Vector3(cellSize, cellSize, 0f);
                }
                else
                {
                    Instantiate(groundGraphicPrefabs[(int)GetComponent<GridToMap>().GetFieldData().terrain], position, transform.rotation, transform).transform.localScale = new Vector3(cellSize, cellSize, 0f);

                    if (GetComponent<GridToMap>().grid._grid[x, y].status == NodeFill.Stone)
                    {
                        GetComponent<GridToMap>().grid._grid[x, y].unitIn = Instantiate(environmantPrefabs[0], position, transform.rotation);
                        GetComponent<GridToMap>().grid._grid[x, y].unitIn.transform.localScale = new Vector3(cellSize, cellSize, 0f);
                    }
                    if (GetComponent<GridToMap>().grid._grid[x, y].status == NodeFill.Tree)
                    {
                        GetComponent<GridToMap>().grid._grid[x, y].unitIn = Instantiate(environmantPrefabs[1], position, transform.rotation);
                        GetComponent<GridToMap>().grid._grid[x, y].unitIn.transform.localScale = new Vector3(cellSize, cellSize, 0f);
                    }
                    if (GetComponent<GridToMap>().grid._grid[x, y].status == NodeFill.Fire)
                    {
                        GetComponent<GridToMap>().grid._grid[x, y].unitIn = Instantiate(environmantPrefabs[3], position, transform.rotation);
                        GetComponent<GridToMap>().grid._grid[x, y].unitIn.transform.localScale = new Vector3(cellSize, cellSize, 0f);
                    }
                }

            }
        }
    }

    public void AddEnvToNode() // хочу зробити типу зверху буде перевірка просто чи не порожній, а тута вже закидати відповідні елементи оточення
    {

    }
}
