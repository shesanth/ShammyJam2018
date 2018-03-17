﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthBoss : MonoBehaviour {

    public List<Vector3> spawnPositions;
    public List<GameObject> TileTypes;

    public float timeBetweenTiles = 8f;
    float nextTilesIn = 0f;

    public float distanceBetweenTiles;

    // Use this for initialization
    void Awake()
    {
        Vector3 newPos = this.transform.position;
        newPos.x += 10;
        spawnPositions.Add(newPos);
        newPos.y += 5;
        spawnPositions.Add(newPos);
        newPos.y += 5;
        spawnPositions.Add(newPos);
    }
	
	// Update is called once per frame
	void Update () {
		if(nextTilesIn <= 0)
        {
            bool hasGround = false;
            nextTilesIn = timeBetweenTiles;
            for(int i = spawnPositions.Count - 1; i >= 0; i--)
            {
                int tileType = (int)Random.Range(0, TileTypes.Count - .01f);
                if(tileType == 1 || tileType == 3)
                {
                    hasGround = true;
                }
                if(i == 0 && !hasGround)
                {
                    GameObject t = Instantiate(TileTypes[3], spawnPositions[i], Quaternion.identity);
                }
                else
                {
                    GameObject t = Instantiate(TileTypes[tileType], spawnPositions[i], Quaternion.identity);
                }
                Vector3 update = spawnPositions[i];
                update.x += distanceBetweenTiles;
                spawnPositions[i] = update;
            }
        }
        nextTilesIn -= Time.deltaTime;
	}
}
