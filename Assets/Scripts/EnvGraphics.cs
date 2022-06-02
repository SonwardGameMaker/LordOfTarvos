using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvGraphics : MonoBehaviour
{
    public List<GameObject> groundGraphicPrefabs = new List<GameObject>();

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
                Instantiate(groundGraphicPrefabs[(int)GetComponent<GridToMap>().GetFieldData().terrain], position, transform.rotation, transform).transform.localScale = new Vector3(cellSize, cellSize, 0f);
            }
        }
    }
}
