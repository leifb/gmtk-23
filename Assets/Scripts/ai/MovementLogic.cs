using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MovementLogic
{


    /// Movement of the AI
    void Move(Transform actor, Transform target, float deltaTime);

  
}
