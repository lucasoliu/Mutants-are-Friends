using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CloneInput : Movement {

    public override Point GetMovement()
    {
        int x, y;
        if (Input.GetKeyDown(KeyCode.A))
        {
            x = -1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            x = 1;
        }
        else
        {
            x = 0;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            y = 1;
        }
        else if (Input.GetKeyDown(KeyCode.S))
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
