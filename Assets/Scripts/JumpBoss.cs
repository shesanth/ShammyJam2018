using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoss : MonoBehaviour {

    public float averageJumpTime; //average time the character will wait before jumping
    public GameObject player; //reference to player object
    public float maxMoveDist; //maximum distance the boss is allowed to jump

    private bool isJumping = false; //bool to prevent mutliple coroutine calls
    private Transform tf;
    private Vector3 startPosTrue;
	// Use this for initialization
	void Start () {
        tf = GetComponent<Transform>();
        startPosTrue = tf.position;
        //StartCoroutine(Jump(5.0f));
	}
	
	// Update is called once per frame
	void Update () {
        
        int faceLeft = 1;
        float xDistToPlayer = tf.position.x - player.GetComponent<Transform>().position.x;
        //first, calculate direction of player
        if (xDistToPlayer < 0)
        {
            faceLeft = 1;
        }//boss is to the left
        else
        {
            faceLeft = -1;
        }
        if (!isJumping)
        {
            //distance the boss will move towards the player
            float moveX = Random.Range(Mathf.Abs(xDistToPlayer)/2, Mathf.Abs(xDistToPlayer) + 2) * faceLeft;
            StartCoroutine(Jump(moveX));
        }
        else
        {
            tf.position = startPosTrue;
        }

    }

    //coroutine that will move the boss
    private IEnumerator Jump(float moveX)
    {
        isJumping = true;
        Vector3 startPos = tf.position;
        Vector3 endPos = new Vector3(tf.position.x + moveX, tf.position.y, tf.position.z);
        for (float i = 0; i < averageJumpTime; i += Time.deltaTime)
        {
            tf.position = Vector3.Slerp(startPos,endPos, i/averageJumpTime);
            yield return null;
        }
        for (float i = 0; i < averageJumpTime; i += Time.deltaTime)
        {
            tf.position = Vector3.Slerp(endPos, startPos, i / averageJumpTime);
            yield return null;
        }
        isJumping = false;
        yield return null;
    }
}
