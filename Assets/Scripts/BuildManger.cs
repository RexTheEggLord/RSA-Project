using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManger : MonoBehaviour{
    public static BuildManger main;

    [SerializeField] private PlantLifeTower[] plantLifeTowers;

    private int currentSelectedBuilding = 0;

    private void Awake()
    {
        main = this;
    }

    public PlantLifeTower GetCurrentSelectedBuilding()
    {
        return plantLifeTowers[currentSelectedBuilding];
    }
    public void setSelectedTower (int _selectedTower)
    {
        currentSelectedBuilding = _selectedTower;
    }
}
