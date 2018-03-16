using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

    private BuildingBlueprint newBuilding;
    private Node selectedNode;
    public NodeUi nodeUi;

    public static BuildingManager instance;

    public GameObject buildEffect;

    public bool CanBuild { get { return newBuilding != null; } }
    public bool HasResources { get { return GameResources.Money >= newBuilding.cost; } }

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        newBuilding = null;	
	}


	// Update is called once per frame
	void Update () {
		
	}

    public void SelectNode( Node node) {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        newBuilding = null;

        nodeUi.SetTarget(node);
    }

    public void DeselectNode() {
        selectedNode = null;
        nodeUi.Hide();
    }

    public void SelectBuildingToBuild(BuildingBlueprint building) {
        newBuilding = building;
        DeselectNode();
    }

    public void BuildSomethingOn(Node node) {

        if (GameResources.Money < newBuilding.cost) {
            Debug.Log("insufficent funds");
            return;
        }

        GameResources.Money -= newBuilding.cost;
        GameObject building = (GameObject)Instantiate(newBuilding.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.building = building;
        GameManager.instance.buildingsOnStage.Add(building);

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }

}
