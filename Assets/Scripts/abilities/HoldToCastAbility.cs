using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HoldToCastAbility : Ability
{
    protected bool _active = false;
    abstract public string name { get; }

    public bool isActive {
        get { return this._active; }
    }

    public void triggerStart() {
        this._active = true;
    }

    public void triggerEnd() {
        this._active = false;
    }
}
