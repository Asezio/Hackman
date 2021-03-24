using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class PlayerInputComponent : MovementComponent
=======
public class PlayerInputComponent : BaseGridMovement
>>>>>>> b0b63039d3f3b217fc8f4e995dd563f619e4b067
{
    protected override void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentInputDirection = new IntVector2(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentInputDirection = new IntVector2(0, -1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentInputDirection = new IntVector2(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentInputDirection = new IntVector2(1, 0);
        }
        base.Update();
    }
}
