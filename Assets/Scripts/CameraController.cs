﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public Vector3 offset;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player(Clone)");
	}
	
	void LateUpdate () {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -2);
	}
}
