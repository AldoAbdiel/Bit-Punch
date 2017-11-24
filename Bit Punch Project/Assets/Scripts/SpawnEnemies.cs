using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

	private float nextSpawnTime;
	private GameObject enemyPrefab;
	[SerializeField]
	private float spawnDelay = 15.0f;

	private void Awake(){
		var enemy = Resources.Load("Enemy");
		enemyPrefab = enemy as GameObject;
	}
	private void Update () {
		if(ShouldSpawn()){
			Spawn();
		}
	}

	private void Spawn(){
		nextSpawnTime = Time.time + spawnDelay;
		Instantiate(enemyPrefab, new Vector3(enemyPrefab.transform.position.x + Random.Range(-0.3f, 0.3f), enemyPrefab.transform.position.y + Random.Range(-0.33f, 0.13f), enemyPrefab.transform.position.z), transform.rotation);
	}

	private bool ShouldSpawn(){
		return Time.time >= nextSpawnTime;
	}
}
