using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Controller : MonoBehaviour
{
    public GameObject grid;

    [SerializeField] private TextMeshProUGUI unitNum;

    private int unitMoveNum = 0;
    private bool battleBegin = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && battleBegin)
        {
            if (unitMoveNum > 0) 
                { grid.GetComponent<GridToMap>().SelectUnit(GetMouseWorldPosition()); }
           
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (battleBegin)
            {
                grid.GetComponent<GridToMap>().MoveUnit(GetMouseWorldPosition(), transform.GetComponent<Controller>());
                unitNum.text = unitMoveNum.ToString();
            }
            else
            {
                grid.GetComponent<GridToMap>().AddUnit(GetMouseWorldPosition());
            }
            
        }

        // Debug Code
        //if (Input.GetMouseButtonDown(1))
        //{
        //    grid.GetComponent<GridToMap>().SpawnTestUnit(GetMouseWorldPosition());
        //}
    }


    private void SetUnits()
    {

    }
    public void EndTurn()
    {
        battleBegin = true;
        unitMoveNum = Random.Range(1, 6);
        unitNum.text = unitMoveNum.ToString();
    }
    public void DecreaseMoveNum()
    {
        if (unitMoveNum > 0) { unitMoveNum--; }
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
