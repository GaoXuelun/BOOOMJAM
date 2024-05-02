using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public bool isGround;
    public float checkRadius;
    public LayerMask groundLayer;

    private void Update()
    {
        groundChecked();
    }
    private void groundChecked()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, groundLayer);
        if (colliders.Length <= 0) isGround = false;
        if (colliders.Length > 0) isGround = true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
