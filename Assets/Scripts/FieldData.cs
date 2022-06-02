using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeatherType { Rain, Snow, Hot, Normal };
public enum TerrainType { Grass, Ground, Mud, Snow, Sand }

public class FieldData
{
    // setters values
    public Dictionary<WeatherType, int> weatherChance;
    public TerrainType terrain;
    public bool isSiege; // чиќблога, не знаю чи нормално переклав

    public List<GameObject> armyPlayer1;
    public List<GameObject> armyPlayer2;

    public bool isLazaretExtendedP1;
    public bool isLazaretExtendedP2;

    // inside values
    public WeatherType weather;
    public int p1LazaretSize;
    public int p2LazaretSize;


    public FieldData() { }
    public FieldData(FieldInputData data)
    {
        SetData(data);
    }

    void Initialize()
    {
        int rand = Random.Range(1, 100);
        int randTemp = 0;
        foreach (KeyValuePair<WeatherType, int> iter in weatherChance)
        {
            if (rand>=randTemp && rand <= randTemp+iter.Value) { weather = iter.Key; break; }
            randTemp += iter.Value;
        }

        if (isLazaretExtendedP1) { p1LazaretSize = 10; }
        else { p1LazaretSize = 5; }
        if (isLazaretExtendedP2) { p2LazaretSize = 10; }
        else { p2LazaretSize = 5; }
    }

    public void SetData(FieldInputData data)
    {
        weatherChance = data.weatherChance;
        terrain = data.terrain;
        isSiege = data.isSiege;
        armyPlayer1 = data.armyPlayer1;
        armyPlayer2 = data.armyPlayer2;
        isLazaretExtendedP1 = data.isLazaretExtendedP1;
        isLazaretExtendedP2 = data.isLazaretExtendedP2;

        Initialize();
    }
}
