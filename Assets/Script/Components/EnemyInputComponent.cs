using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rider
//Resharper (Visual studio plugin, Jetbrains
<<<<<<< HEAD
public class EnemyInputComponent : MovementComponent
=======
public class EnemyInputComponent : BaseGridMovement
>>>>>>> b0b63039d3f3b217fc8f4e995dd563f619e4b067
{
    private IntVector2[] movementDirections = new IntVector2[]
    {
        new IntVector2(0,1),
        new IntVector2(0,-1),
        new IntVector2(-1,0),
        new IntVector2(1,0),
    };
    protected override void Update()
    {
        //If we've arrived, we need to set a new current input direction (the ghost can't stop)
<<<<<<< HEAD
        if(transform.position == targetGridPosition.AsToIntVectr2())
=======
        if(transform.position == targetGridPosition.ToVector3())
>>>>>>> b0b63039d3f3b217fc8f4e995dd563f619e4b067
        {
            var possibleDirections = new List<IntVector2>();
            
            foreach (var movementDirection in movementDirections)
            {
                if (movementDirection == -currentInputDirection) continue;

                var potentialTargetPosition = targetGridPosition + movementDirection;

                if (LevelGeneratorSystem.Grid[Mathf.Abs(potentialTargetPosition.y),
                    Mathf.Abs(potentialTargetPosition.x)] != 1)
                {
                    possibleDirections.Add(movementDirection);
                }
            }

            if (possibleDirections.Count < 1)
            {
                possibleDirections.Add(-currentInputDirection);
            }

            //if(!possibleDirections.Any())
            //{
            //    possibleDirections.Add(-currentInputDirection);
            //}

            var direction = Random.Range(0, possibleDirections.Count);
            currentInputDirection = possibleDirections[direction];
        }
        base.Update();
    }
}
