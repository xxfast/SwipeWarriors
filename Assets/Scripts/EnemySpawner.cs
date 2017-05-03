using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    // Object Refernces
    [Header("Object Refernces:")]
    public GameObject Target;

    // Spawner Settings
    [Header("Settings:")]
    public int ID;
    public float SpawnDistance;
    public float SpawnFrequancy;
    public float SpawnFor;

    public List<Object> WhatToSpawn;

    // Base Variables
    private float respawnTime;
    private float waveTime;

    // Flags
    [Header("Flags:")]
    public bool DebugMessages;

    public EnemySpawner(WaveProfile waveProfile)
    {
        AttachProfile(waveProfile);
    }

    // Use this for initialization
    void Start () {
        respawnTime = SpawnFrequancy;
        waveTime = SpawnFor;
	}
	
	// Update is called once per frame
	void Update () {
        respawnTime -= Time.deltaTime;
        waveTime -= Time.deltaTime;
        if (respawnTime < 0 && WhatToSpawn != null && WhatToSpawn.Count > 0)
        {
            Spawn();
            respawnTime = SpawnFrequancy;
        }
        if (waveTime <= 0)
            this.enabled = false;
    }

    /// <summary>
    /// Spawns a single enemy instance.
    /// </summary>
    private void Spawn()
    {
        float angle = Random.Range(0.0f, 1.0f) * Mathf.PI * 2.0f;
        float radius = SpawnDistance;
        float x = Mathf.Cos(angle) * radius + this.transform.position.x;
        float y = Mathf.Sin(angle) * radius + this.transform.position.y;

        int index = Random.Range(0, WhatToSpawn.Count - 1);
        if (DebugMessages) Debug.Log("Range = " + index);

        Object prefab = WhatToSpawn[index];

        if(prefab)
        {
            GameObject enemy = Instantiate(prefab, new Vector3(x, y, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
            enemy.GetComponent<FollowTarget>().target = Target;
        }
    }

    /// <summary>
    /// Attaches profile to current enemy spawner.
    /// </summary>
    /// <param name="waveProfile">Profile to attach.</param>
    public void AttachProfile(WaveProfile waveProfile)
    {
        SpawnDistance = waveProfile.SpawnDistance;
        SpawnFrequancy = waveProfile.SpawnFrequancy;
        SpawnFor = waveProfile.SpawnFor;
        WhatToSpawn = waveProfile.WhatToSpawn;
    }

    public bool HasEnded
    {
        get
        {
            return !this.enabled;
        }
    }
}
