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
        for (int i = 0; i < 5000; i++) {
            GameObject nd = Instantiate(nodePrefab, pos,Quaternion.identity);
            nd.transform.localPosition = pos;
            nd.transform.SetParent(nodeParent);
            if (pos.x == 140)
                pos = new Vector3(0, pos.y, pos.z + 5);
            else if (pos.z <= 80)
                pos = new Vector3(pos.x + 5, pos.y, pos.z);
            else
                break;
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
