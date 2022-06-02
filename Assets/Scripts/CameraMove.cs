using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject grid;


    // Start is called before the first frame update
    void Start()
    {
        float x = grid.GetComponent<GridToMap>().wight * grid.GetComponent<GridToMap>().cellSize / 2;
        float y = grid.GetComponent<GridToMap>().heigth * grid.GetComponent<GridToMap>().cellSize / 2;
        transform.Translate( new Vector3(x, y, transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
