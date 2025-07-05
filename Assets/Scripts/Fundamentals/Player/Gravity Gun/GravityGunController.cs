using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/* -----------------------------------------------------------
 * Author:
 * 
 * 
 * Modified By:
 * 
 */// --------------------------------------------------------

/* -----------------------------------------------------------
 * Purpose:
 * 
 */// --------------------------------------------------------


/// <summary>
/// 
/// </summary>
public class GravityGunController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _gravigunPivot;
    [SerializeField] private Transform _helperTargetCircleTransform;
    [SerializeField] private LineRenderer _lineRenderer;
    
    [Header("Settings")]
    [SerializeField] private float _gravigunAngleOffset;
    [SerializeField, Range(0f,100f)] private float _maxRaycastDistance;
    [SerializeField] private LayerMask _lineRaycastMask;
    
    [Header("Debugging")]
    [SerializeField, InspectorReadOnly] private GameObject _focusedObject;
    [SerializeField] private bool doDebugLog;
    
    // Local variables
    

    private void Update()
    {
        // 1. Convert mouse position to world space
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = transform.position.z;          // flatten to sprite’s plane

        // Direction from sprite to mouse
        Vector2 dir = mouseWorld - _gravigunPivot.position;

        // Compute angle (0° = +X). Convert to degrees.
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        
        // 4. Rotate around Z so +Y faces the cursor
        _gravigunPivot.rotation = Quaternion.AngleAxis(angle + _gravigunAngleOffset, Vector3.forward);
        
        // Fire a raycast in the direction of the mouse
        RaycastHit2D hit = Physics2D.Raycast(_gravigunPivot.position, dir, _maxRaycastDistance, _lineRaycastMask);

        if (hit)
        {
            // We did hit something
            
            // Update Line Renderer
            UpdateLineRenderer(_gravigunPivot.position, Vector2.zero, hit.point, 0f);

        }
        else
        {
            // we didnt hit anything
            UpdateLineRenderer(_gravigunPivot.position, dir, Vector2.zero, _maxRaycastDistance);
        }
    }
    
    //private void Comp
    
    // REMEMBER TO DISABLE LINE RENDERER WHEN HOLDING SOMETHING

    private void UpdateLineRenderer(Vector2 origin, Vector2 dir, Vector2 target, float distance)
    {
        _lineRenderer.SetPosition(0, origin);
        Vector2 finalPos = Vector2.zero;
        
        if (dir == Vector2.zero)
        {
            // We do have a target
            finalPos = target;
            _lineRenderer.SetPosition(1, target);
        }
        else
        {
            // We dont have a target
            finalPos = dir * distance;
            _lineRenderer.SetPosition(1, finalPos);
        }
        
        // Update helper circle
        _helperTargetCircleTransform.position = finalPos;
    }
    
    
    #if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        
    }
    
    
    #endif
    
}
