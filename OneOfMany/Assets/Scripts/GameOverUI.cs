using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour {

    public Text wavesText;

    private void OnEnable()
    {
        wavesText.text = PlayerStats.waves.ToString();
    }

    void Start () {
		
	}
	

	void Update () {
		
	}

    public void Retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu() {
        Debug.Log("Go to Menu");
    }
}
