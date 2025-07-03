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
public class Outline2D : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Material _outlineMaterial;
    
    [Header("Settings")]
    [SerializeField, Range(-10f,0)] private float _offsetLeft = -1f;
    [SerializeField, Range(0,10f)] private float _offsetRight = 1f;
    [SerializeField, Range(0,10f)] private float _offsetUp = 1f;
    [SerializeField, Range(-10,0)] private float _offsetDown = -1f;
    [SerializeField] private Color _outlineColor = Color.green;
    
    [Header("Buttons")]
    [SerializeField] private bool _applySettings;
    [SerializeField] private bool _enableOutline;
    [SerializeField] private bool _disableOutline;
    
    // Use this bool to gate all your Debug.Log Statements please
    [Header("Debugging")]
    [SerializeField] private bool _doDebugLog;
    
    // Local variables
    private static readonly int offsetLeftID = Shader.PropertyToID("_Offset_Left");
    private static readonly int offsetRightID = Shader.PropertyToID("_Offset_Right");
    private static readonly int offsetUpID = Shader.PropertyToID("_Offset_Up");
    private static readonly int offsetDownID = Shader.PropertyToID("_Offset_Down");
    private static readonly int outlineColorID = Shader.PropertyToID("_Outline_Color");
    private static readonly int OutlineOnID = Shader.PropertyToID("_Outline_On");
    
    void Awake()
    {
        // Replace sprite renderer material with outline shader
        _spriteRenderer.material = _outlineMaterial;
        
        ApplySettings();
    }

    // Check inspector buttons
    void Update()
    {
        if (_applySettings)
        {
            ApplySettings();
            _applySettings = false;
        }

        if (_enableOutline)
        {
            EnableOutline();
            _enableOutline = false;
        }

        if (_disableOutline)
        {
            DisableOutline();
            _disableOutline = false;
        }
    }

    private void ApplySettings()
    {
        _spriteRenderer.material.SetFloat(offsetLeftID, _offsetLeft);
        _spriteRenderer.material.SetFloat(offsetRightID, _offsetRight);
        _spriteRenderer.material.SetFloat(offsetUpID, _offsetUp);
        _spriteRenderer.material.SetFloat(offsetDownID, _offsetDown);
        _spriteRenderer.material.SetColor(outlineColorID, _outlineColor);
    }

    public void EnableOutline()
    {
        _spriteRenderer.material.SetInt(OutlineOnID, 1);
    }

    public void DisableOutline()
    {
        _spriteRenderer.material.SetInt(OutlineOnID, 0);
    }
}
