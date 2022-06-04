using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalDataSim : MonoBehaviour
{
    public Dictionary<WeatherType, int> weatherChance;
    public TerrainType terrain = TerrainType.Grass;
    public bool isSiege; // чи облога

    public List<GameObject> armyPlayer1;
    public List<GameObject> armyPlayer2;

    public bool p1LazaretExtend;
    public bool p2LazaretExetnd;

    FieldInputData data;

    // Start is called before the first frame update
    void Awake()
    {
        weatherChance = new Dictionary<WeatherType, int>();
        weatherChance.Add(WeatherType.Rain, 25);
        weatherChance.Add(WeatherType.Snow, 25);
        weatherChance.Add(WeatherType.Hot, 25);
        weatherChance.Add(WeatherType.Normal, 25);

        data = new FieldInputData();

        data.weatherChance = weatherChance;
        data.terrain = terrain;
        data.isSiege = isSiege;

        data.armyPlayer1 = armyPlayer1;
        data.armyPlayer2 = armyPlayer2;

        data.isLazaretExtendedP1 = p1LazaretExtend;
        data.isLazaretExtendedP2 = p2LazaretExetnd;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateData()
    {
       
    }
    public FieldInputData GetData()
    {
        return data;
    }
}
