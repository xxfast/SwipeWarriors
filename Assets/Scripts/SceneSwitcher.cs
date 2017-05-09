using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

	public void SwitchScene(int toload){
		SceneManager.UnloadSceneAsync (SceneManager.GetActiveScene().buildIndex);
		SceneManager.LoadScene(toload, LoadSceneMode.Single);
	}
}
