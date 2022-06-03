using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldInputData
{
    public Dictionary<WeatherType, int> weatherChance;
    public TerrainType terrain;
    public bool isSiege; // чиќблога, не знаю чи нормално переклав

    public List<GameObject> armyPlayer1;
    public List<GameObject> armyPlayer2;

    public bool isLazaretExtendedP1;
    public bool isLazaretExtendedP2;
}
