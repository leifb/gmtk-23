using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScan
{
    public readonly Collider2D collider;
    public readonly float distance;
    public readonly Distance distanceClass;
    public readonly bool isEnemy;
    
    public HeroScan(Collider2D collider, float distance, Distance distanceClass, bool isEnemy) {
        this.collider = collider;
        this.distance = distance;
        this.distanceClass = distanceClass;
        this.isEnemy = isEnemy;
    }

    public bool free { 
        get { return this.distanceClass == Distance.Free; }
    }

    public bool close {
        get { return this.distanceClass == Distance.Close; }
    }

    public bool visible {
        get { return this.distanceClass == Distance.Visible; }
    }

    public static HeroScan From(Transform source, Vector2 direction, float distance, double closeCutoff) {
        RaycastHit2D hit = Physics2D.Raycast(source.position, direction, distance, LayerMask.GetMask("Enemies", "World"));
        if (hit.transform == null) {
            return new HeroScan(null, distance, Distance.Free, false);
        }
        var isEnemy = hit.transform.gameObject.layer == LayerMask.NameToLayer("Enemies");
        var distanceGroup = hit.distance < closeCutoff ? Distance.Close : Distance.Visible;
        return new HeroScan(hit.collider, hit.distance, distanceGroup, isEnemy);
    }

    public enum Distance {
        Close,
        Visible,
        Free
    }
}
