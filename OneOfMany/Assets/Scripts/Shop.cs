using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public BuildingBlueprint standardTurret;
    public BuildingBlueprint missileLauncher;
    public BuildingBlueprint laserBeamer;

    BuildingManager buildManager;

	void Start () {
        buildManager = BuildingManager.instance;
	}
	

	void Update () {
		
	}

    public void SelectStandardTurret() {
        buildManager.SelectBuildingToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectBuildingToBuild(missileLauncher);
    }

    public void SelectLaserBeamer() {
        buildManager.SelectBuildingToBuild(laserBeamer);
    }
}
