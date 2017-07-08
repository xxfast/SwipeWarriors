using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {

    public Transform generateAround;
    public GameObject[] objects;
    public float maxObstacleCount;
    public float spawnRange;
    public float despawnRange;
	// Use this for initialization
	void Start () {
        var obstacles = FindObjectsOfType<Obstacle>();
        var obstacleCount = obstacles.Length;
        foreach (var obs in obstacles) {
            if (Vector3.Distance(obs.transform.position, generateAround.position) > despawnRange)
                Destroy(obs.gameObject);
        }
        for (var i = 0; obstacleCount < maxObstacleCount && i < maxObstacleCount; i++) {
            Instantiate(objects[Mathf.RoundToInt(Random.Range(0, objects.Length - 1))], spawnRange * (Vector3)Random.insideUnitCircle + generateAround.position, Quaternion.Euler(0,0,Random.Range(0,360)), transform);
            obstacleCount++;
        }
    }
	
	// Update is called once per frame
	void Update () {
        var obstacles = FindObjectsOfType<Obstacle>();
        var obstacleCount = obstacles.Length;
        foreach (var obs in obstacles) {
            if (Vector3.Distance(obs.transform.position, generateAround.position) > despawnRange)
                Destroy(obs.gameObject);
        }
        for (var i = 0; obstacleCount < maxObstacleCount && i < maxObstacleCount; i++) {
            var obs = Instantiate(objects[Mathf.RoundToInt(Random.Range(0, objects.Length - 1))], (Random.Range(0, despawnRange - spawnRange) + spawnRange) * (Vector3)Random.insideUnitCircle.normalized + generateAround.position, Quaternion.Euler(0, 0, Random.Range(0, 360)), transform);
             obstacleCount++;
        }
    }
}
