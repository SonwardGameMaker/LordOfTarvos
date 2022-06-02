using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TroopType { HeavyCavalry, LightCavalry, HeavyInfantry, LightInfantry, Shooters, Monster, AuxilliaryTroops, Machines };

public class UnitData : MonoBehaviour
{
    public string unitName;
    public bool isAlive;

    public int defaultHP;
    public int realHP;
    
    public int defaultDamage;
    public int realDamage;

    public int defaultSpeed;
    public int realSpeed;

    public TroopType type;

    // TODO
    // Abilities

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
