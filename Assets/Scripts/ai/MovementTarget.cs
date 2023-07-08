using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTarget : MonoBehaviour
{
    private Transform target;

    public Transform get() {
        return this.target;
    }

    public void set(Transform target) {
        this.target = target;
    }

    public bool isValid() {
        return this.target != null;
    }
}
