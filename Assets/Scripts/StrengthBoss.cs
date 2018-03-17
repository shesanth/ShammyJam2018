using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthBoss : MonoBehaviour {

    public List<Vector3> spawnPositions;
    public List<GameObject> TileTypes;

    public float timeBetweenTiles = 8f;
    float nextTilesIn = 20f;

    public float distanceBetweenTiles;

	// Use this for initialization
	void Awake() {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(nextTilesIn <= 0)
        {
            nextTilesIn = timeBetweenTiles;
            for(int i =0; i < spawnPositions.Count; i++)
            {
                GameObject t = Instantiate(TileTypes[(int)Random.Range(0, TileTypes.Count - .01f)], spawnPositions[i], Quaternion.identity);
                Vector3 update = spawnPositions[i];
                update.x += distanceBetweenTiles;
                spawnPositions[i] = update;
            }
        }
        nextTilesIn -= Time.deltaTime;
	}
}
