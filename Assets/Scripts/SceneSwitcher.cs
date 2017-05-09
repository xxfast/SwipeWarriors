﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

	public void SwitchScene(string toload){
		SceneManager.LoadScene(toload, LoadSceneMode.Additive);
	}
}
