using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ability
{
    string name { get; }
    bool isActive { get; }

    int value { get; }

    void triggerStart();

    void triggerEnd();
}
