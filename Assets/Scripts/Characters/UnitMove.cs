using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    public float speed = 100.0f;

    private bool mustMove = false;
    private Vector3 destinationPoin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mustMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, destinationPoin, speed*Time.deltaTime);
            if (transform.position == destinationPoin) { mustMove = false; }
        }
    }

    public void StartMove(Vector3 destPoint)
    {
        destinationPoin = destPoint;
        mustMove = true;
    }
}
