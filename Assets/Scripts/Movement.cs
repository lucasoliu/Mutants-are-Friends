using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour {
    private Point pos;
    public List<List<GameObject>> tiles;
    private float nextMove;
    public float moveCooldown = 0f;

    // Use this for initialization
    void Awake () {
        tiles = GameObject.Find("Map").GetComponent<GameController>().tiles;
        pos = Utils.positionToPoint(transform.position);
        nextMove = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (nextMove <= Time.time)
        {
            Point moveInput = GetMovement();
            int xInput = moveInput.x;
            int yInput = moveInput.y;
            if (xInput != 0 || yInput != 0)
            {
                Point newPos = new Point(pos.x + xInput, pos.y + yInput);
                if (!CanMove(tiles[newPos.x][newPos.y]))
                {
                    return;
                }
                pos = newPos;
                Vector3 newPosition = Utils.indexToVector(pos.x, pos.y, Utils.playerLayer);
                transform.position = newPosition;
                nextMove = Time.time + moveCooldown;
            }
        }
    }

    public abstract bool CanMove(GameObject tile);

    public abstract Point GetMovement();
}
