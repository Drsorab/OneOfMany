using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public GameObject building;

    public Color hoverColor;
    public Vector3 yOffset;
    public Color startColor;
    private Renderer rend;
    public Color notEnoughMoneyColor;

    BuildingManager buildManager;

	void Start () {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildingManager.instance;
	}

    public Vector3 GetBuildPosition()
    {
        return transform.position + yOffset;
    }

    void Update () {
		
	}

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasResources)
        {
            rend.material.color = hoverColor;
        }
        else {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (building != null) {
            Debug.Log("OCCUPIED");
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        buildManager.BuildSomethingOn(this);

    }
    public void Test() {
        //if(rend.material.color != hoverColor)
            rend.material.color = hoverColor;
        GetComponent<MeshRenderer>().enabled = true;
        //else
        //    rend.material.color = startColor;
        GetComponent<NavMeshObstacle>().enabled = true;
    }
}
