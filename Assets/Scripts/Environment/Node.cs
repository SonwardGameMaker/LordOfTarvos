using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeFill {Empty, Unit, Wall, Gate, Stone, Tree, Water, Fire};

public class Node
{
    public NodeFill status;
    public GameObject unitIn;

    public Node() { status = NodeFill.Empty; }
    public Node(GameObject unit)
    {
        status = NodeFill.Unit;
        unitIn = unit;
    }

    public void AddUnit(GameObject unit)
    {
        status = NodeFill.Unit;
        unitIn = unit;
    }
    public void RemoveUnit()
    {
        status = NodeFill.Empty;
        unitIn = null;
    }
}
