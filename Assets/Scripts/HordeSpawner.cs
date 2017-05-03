using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeSpawner : MonoBehaviour {
    // Object Refernces
    [Header("Object Refernces:")]
    public GameObject Target;

    // Settings
    [Header("Spawner Settings:")]
    public float TimeBetweenWaves;

    // Wave Settings
    [Header("Wave Settings:")]
    [Tooltip("Wave descriptions for each of the waves.")]
    public WaveProfileList WaveProfiles;

    // Base Variables
    [Header("Variables:")]
    [SerializeField]
    private int currentWaveNumber;
    private List<EnemySpawner> waves;
    private float time;

    // Use this for initialization
    void Start () {
        if (WaveProfiles == null)
            WaveProfiles = new WaveProfileList();
        if (Target == null)
            Target = GameObject.Find("Player");
        waves = new List<EnemySpawner>();
        currentWaveNumber = 0;
        time = TimeBetweenWaves;
	}
	
	// Update is called once per frame
	void Update () {
		if (waves.Count == 0 || waves[currentWaveNumber-1].HasEnded)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = TimeBetweenWaves;
                CommenseHorde();
            }
        }
	}

    /// <summary>
    /// Commences Horde of Enemies.
    /// </summary>
    private void CommenseHorde()
    {
        if (WaveProfiles.Waves != null && WaveProfiles.Waves.Count > 0 && currentWaveNumber < WaveProfiles.Waves.Count)
        {
            waves.Add(gameObject.AddComponent(typeof(EnemySpawner)) as EnemySpawner);
            WaveProfile current = WaveProfiles.Waves[currentWaveNumber];
            waves[currentWaveNumber].enabled = true;
            waves[currentWaveNumber].AttachProfile(current);
            waves[currentWaveNumber].Target = Target;
            waves[currentWaveNumber].ID = currentWaveNumber;
            currentWaveNumber++;
        }
        else
            this.enabled = false;
    }
}
