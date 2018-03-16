using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //TODO enum game states
    public bool gameOver = false;
    public GameObject gameOverUi;
    public List<GameObject> buildingsOnStage = new List<GameObject>();
    public List<Transform> nodes = new List<Transform>();
    public Transform nodeParent;
    public static GameManager instance;
    public GameObject nodePrefab;
    private void Awake()
    {
        instance = this;
        Vector3 pos = Vector3.zero;
        for (int i = 0; i < 10850; i++) {
            GameObject nd = Instantiate(nodePrefab, pos,Quaternion.identity);
            nd.transform.localPosition = pos;
            nd.transform.SetParent(nodeParent);
            if(i%139==0 && i!=0)
                pos = new Vector3(0, pos.y, pos.z+10);
            else
                pos = new Vector3(pos.x + 10, pos.y, pos.z);
        }
    }


    void Start () {
        foreach (Transform n in nodeParent) {
            nodes.Add(n);
        }
	}
	

	void Update () {
        if (gameOver)
            return;

        if (PlayerStats.lives <= 0)
            EndGame();
		
	}

    void EndGame() {
        gameOver = true;
        gameOverUi.SetActive(true);
        Debug.Log("GameOver");
    }
}
