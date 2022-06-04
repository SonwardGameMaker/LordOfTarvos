using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridToMap : MonoBehaviour
{
    public GameObject fromGlobalMap;

    public int wight = 2;
    public int heigth = 5;
    public float cellSize = 2f;

    public UnitMove testUnit;
    public GameObject myPrefab; // то дебагав чи нормально координати передає, знизу закоменчений код

    public MyGrid grid;
    private GameObject chosenUnit;
    private int x1, y1, x2, y2;

    private FieldData fieldData;

    // Debug
    public WeatherType weather;

    // Start is called before the first frame update
    void Start()
    {
        grid = new MyGrid(wight, heigth, cellSize);

        DebugInitialize();

        fieldData = new FieldData(fromGlobalMap.GetComponent<GlobalDataSim>().GetData());

        GetComponent<EnvGraphics>().SetTerrain(fieldData.terrain);

        //FieldDataLog();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void SelectUnit(Vector3 mousePosition)
    {
        Node node = grid.GetValue(mousePosition);
        if (node != null)
        {
            grid.GetXY(mousePosition, out x1, out y1);
            if (node.status == NodeFill.Unit)
            {
                //Debug.Log("Unit chosed");
                chosenUnit = node.unitIn;
            }
        }
    }
    public void MoveUnit(Vector3 mousePosition, Controller controller)
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

                controller.DecreaseMoveNum();
            }
        }
    }
    public void AddUnit(Vector3 mousePosition)
    {
        int x, y;

        Node node = grid.GetValue(mousePosition);
        if (node.status == NodeFill.Empty)
        {
            Node updatedNode = new Node();
            updatedNode.status = NodeFill.Unit;
            grid.GetXY(mousePosition, out x, out y);

            updatedNode.unitIn = Instantiate(myPrefab, CellNumToWorldPosition(x, y, 0f), transform.rotation);
            grid.SetValue(x, y, updatedNode);

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
    public void DebugInitialize()
    {
        Node updatedNode;

        // Add tests units
        updatedNode = new Node(testUnit.gameObject);
        grid.SetValue(0, 0, updatedNode);
        testUnit.transform.Translate(new Vector3(1, 1, testUnit.transform.position.z), Space.World);

        // Add environment
        updatedNode = new Node();
        updatedNode.status = NodeFill.Stone;
        grid.SetValue(5, 2, updatedNode);

        updatedNode = new Node();
        updatedNode.status = NodeFill.Fire;
        grid.SetValue(6, 4, updatedNode);

        updatedNode = new Node();
        updatedNode.status = NodeFill.Water;
        grid.SetValue(7, 1, updatedNode);

        updatedNode = new Node();
        updatedNode.status = NodeFill.Tree;
        grid.SetValue(5, 7, updatedNode);

        updatedNode = new Node();
        updatedNode.status = NodeFill.Water;
        grid.SetValue(7, 2, updatedNode);
    }
}
