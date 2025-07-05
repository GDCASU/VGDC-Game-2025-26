using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* -----------------------------------------------------------
 * Author:
 * Ian Fletcher
 * 
 * Modified By:
 * 
 */// --------------------------------------------------------

/* -----------------------------------------------------------
 * Purpose:
 * Provide a class for all physics objects on the game
 */// --------------------------------------------------------


/// <summary>
/// Abstract class that governs all physics objects
/// </summary>
public abstract class PhysicsObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField] protected Outline2D _outline;
    [SerializeField] protected Collider2D _collider;
    [SerializeField] protected Rigidbody2D _rigidbody;
    
    [Header("Settings")]
    public PhysicsObjectType physicsObjectType;
    
    [Header("Readouts")]
    [InspectorReadOnly] public bool isTargeted;
    
    public virtual void ChangeOutlineColor(Color color)
    {
        _outline.ChangeColor(color);
    }

    public virtual void EnableTarget()
    {
        isTargeted = true;
        _outline.SetOutline(true);
    }

    public virtual void DisableTarget()
    {
        isTargeted = false;
        _outline.SetOutline(false);
    }
}

public enum PhysicsObjectType
{
    Grabbable,
    Influenceable,
    IgnoresGravigun,
}
