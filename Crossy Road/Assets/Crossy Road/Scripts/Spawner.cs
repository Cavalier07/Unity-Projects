using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	public Transform startPosition = null;

	//Spawn Time Based
	public float delayMin = 1.5f;
	public float delayMax = 5;
	public float speedMin = 1;
	public float speedMax = 4;

	//Spawn at Start
	public bool useSpawnPlacement = false;
	public int spawnCountMin = 4;
	public int spawnCountMax = 20;

	private float lastTime = 0;
	private float delayTime = 0;
	private float speed = 0;

	[HideInInspector]
	public GameObject item = null;

	[HideInInspector]
	public bool goLeft = false;

	[HideInInspector]
	public float spawnLeftPosition = 0;

	[HideInInspector]
	public float spawnRightPosition = 0;

	void Start()
	{
		if (useSpawnPlacement) 
		{
			int spawnCount = Random.Range(spawnCountMin , spawnCountMax);

			for (int i = 0; i < spawnCount; i++) 
			{
				SpawnItem ();
			}
		} 
		else 
		{
			speed = Random.Range (speedMin, speedMax);

		}
	}

	void Update()
	{
		if (useSpawnPlacement) 
		{
			return;
		}

		if (Time.time > lastTime + delayTime) 
		{
			lastTime = Time.time;

			delayTime = Random.Range (delayMin, delayMax);

			SpawnItem ();
		}
	}

	void SpawnItem()
	{
		Debug.Log ("Spawner :: SpawnItem :: Spawning New Item");

		GameObject obj = Instantiate(item) as GameObject;

		obj.transform.position = GetSpawnPosition ();

		float direction = 0;

		if (goLeft)
			direction = 180;

		if (!useSpawnPlacement) 
		{
			obj.GetComponent<Mover> ().speed = speed;

			obj.transform.rotation = obj.transform.rotation * Quaternion.Euler (0, direction, 0);
		}
	}

	Vector3 GetSpawnPosition()
	{
		if (useSpawnPlacement) 
		{
			return new Vector3 (Random.Range (spawnLeftPosition, spawnRightPosition), startPosition.position.y, startPosition.position.z);
		} 
		else 
		{
			return startPosition.position;
		}
	}

}
