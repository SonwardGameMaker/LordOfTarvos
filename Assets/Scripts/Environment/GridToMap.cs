using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridToMap : MonoBehaviour
{
    public GameObject fromGlobalMap;

    public int wight = 2;
    public int heigth = 5;
    public float cellSize = 2f;

    public GameObject testUnit;
    public GameObject myPrefab; // �� ������� �� ��������� ���������� ������, ����� ������������ ���

    private MyGrid grid;
    private GameObject chosenUnit;
    private int x1, y1, x2, y2;

    private FieldData fieldData;

    // Debug
    public WeatherType weather;

    // Start is called before the first frame update
    void Start()
    {
        grid = new MyGrid(wight, heigth, cellSize);

        Node updatedNode = new Node(testUnit);
        grid.SetValue(0, 0, updatedNode);
        testUnit.transform.Translate(new Vector3(1, 1, testUnit.transform.position.z), Space.World);

        fieldData = new FieldData(fromGlobalMap.GetComponent<GlobalDataSim>().GetData());

        GetComponent<EnvGraphics>().SetTerrain(fieldData.terrain);

        FieldDataLog();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void SelectUnit(Vector3 mousePosition)
    {
        Node node = grid.GetValue(mousePosition);
        grid.GetXY(mousePosition, out x1, out y1);
        if (node.status == NodeFill.Unit)
        {
            Debug.Log("Unit chosed");
            chosenUnit = node.unitIn;
        }
    }
    public void MoveUnit(Vector3 mousePosition)
    {
        if (chosenUnit != null)
        {
            Node node = grid.GetValue(mousePosition);
            if (node.status == NodeFill.Empty)
            {
                Node updatedNode = new Node();
                updatedNode.status = NodeFill.Unit;
                updatedNode.unitIn = chosenUnit;

                grid.GetXY(mousePosition, out x2, out y2);
                grid.SetValue(x2, y2, updatedNode);
                
                chosenUnit.GetComponent<UnitMove>().StartMove(CellNumToWorldPosition(x2, y2, chosenUnit.transform.position.z));


                grid.SetValue(x1, y1, new Node());
                chosenUnit = null;
            }
        }
    }

    public FieldData GetFieldData()
    {
        return fieldData;
    }
    public Vector3 CellNumToWorldPosition(int x, int y, float z)
    {
        //return new Vector3(x * cellSize, y * cellSize, z);
        return new Vector3((x+1) * cellSize - cellSize/2, (y+1) * cellSize - cellSize/2, z);
    }

    // Debug func
    public void FieldDataLog()
    {
        Debug.Log(fieldData.weatherChance);
        Debug.Log("Weather: " + fieldData.weather);
        Debug.Log("Terrrain: " + fieldData.terrain);
        Debug.Log("Is Siege: " + fieldData.isSiege);
        Debug.Log("P1 Lazaret Extend: " + fieldData.isLazaretExtendedP1);
        Debug.Log("P2 Lazaret Extend: " + fieldData.isLazaretExtendedP2);
        Debug.Log("P1 Lazaret Size: " + fieldData.p1LazaretSize);
        Debug.Log("P2 Lazaret Size: " + fieldData.p2LazaretSize);
    }
    public void SpawnTestUnit(Vector3 mousePosition)
    {
        Debug.Log("Mouse Postion: " + mousePosition);
        grid.GetXY(mousePosition, out x2, out y2);
        Debug.Log("Grid Mouse Position: " + CellNumToWorldPosition(x2, y2, mousePosition.z));
        Instantiate(myPrefab, CellNumToWorldPosition(x2, y2, 0), myPrefab.transform.rotation);
    }
}