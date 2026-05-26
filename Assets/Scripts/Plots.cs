using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plots : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    //[SerializeField] private GameObject buildMenuPlant;
    //[SerializeField] private GameObject buildMenuIndustrial;

    private GameObject tower;
    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
    }
    private void OnMouseEnter()
    {

        sr.color = hoverColor;
    }
    private void OnMouseExit()
    {
        sr.color = startColor;
    }
    private void OnMouseDown()
    {

        if (tower != null) return;

        PlantLifeTower towerToBuild = BuildManger.main.GetCurrentSelectedBuilding();

        if (towerToBuild.cost > levelManger.main.currency)
        {
            return;
        }

        levelManger.main.SpendCurrency(towerToBuild.cost);

        tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
    }

}
