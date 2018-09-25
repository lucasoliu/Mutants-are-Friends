using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement {

    public override bool CanMove(GameObject tile) {
        return !(tile.CompareTag("Wall") || tile.CompareTag("Water"));
    }

    public override Point GetMovement() {
        int x, y;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            x = -1;
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            x = 1;
        } else {
            x = 0;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            y = 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            y = -1;
        }
        else
        {
            y = 0;
        }
        return new Point(x, y);
    }
}
