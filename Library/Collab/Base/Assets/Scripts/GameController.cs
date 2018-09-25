using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private List<List<GameObject>> tiles;

    public int tileWidth = 1;
    public GameObject floor;
    public GameObject wall;
    public GameObject water;
    public GameObject door;

    // Use this for initialization
    void Start () {
        InitializeLevel();
	}

    // Create Testing Level
    private void InitializeLevel() {
        tiles = new List<List<GameObject>>();
        for (int i = 0; i < 5; i++)
        {
            List<GameObject> currentRow = new List<GameObject>();
            tiles.Add(currentRow);
            for (int j = 0; j < 7; j++) {
                GameObject currentTile;
                if (j == 0 || j == 6 || i == 0 || i == 4) {
                    currentTile = Instantiate(wall, indexToVector(j, i),
                                                     Quaternion.identity);
                } else {
                    currentTile = Instantiate(floor, indexToVector(j, i),
                                                     Quaternion.identity);
                }
                currentRow.Add(currentTile);
            }
        }
    }

    public Vector3 indexToVector(int x, int y) {
        return new Vector3(x * tileWidth, y * tileWidth, 0f);
    } 
/*
    public Point indexToPosition(int xInd, int yInd) {
        return new Point(xInd * tileWidth, yInd * tileWidth);
    }*/
}
