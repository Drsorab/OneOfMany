using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUi : MonoBehaviour {

    private Node target;
    public GameObject ui;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetTarget(Node tr)
    {
        target = tr;
        transform.position = target.GetBuildPosition();
        ui.SetActive(true);
    }

    public void Hide() {
        ui.SetActive(false);
    }
}
