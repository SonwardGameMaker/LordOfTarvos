using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Controller : MonoBehaviour
{
    public GameObject grid;

    private int unitMoveNum;

    // Start is called before the first frame update
    void Start()
    {
        EndTurn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.GetComponent<GridToMap>().SelectUnit(GetMouseWorldPosition());
        }
        if (Input.GetMouseButtonDown(1))
        {
            grid.GetComponent<GridToMap>().MoveUnit(GetMouseWorldPosition());
        }

        // Debug Code
        //if (Input.GetMouseButtonDown(1))
        //{
        //    grid.GetComponent<GridToMap>().SpawnTestUnit(GetMouseWorldPosition());
        //}
    }

    public void EndTurn()
    {
        unitMoveNum = Random.Range(1, 6);
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
