using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : CloneInput {

    public override bool CanMove(GameObject tile)
    {
        return !(tile.CompareTag("Wall"));
    }
}
