using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceObjectsOnPlane : MonoBehaviour
{

    /// <summary>
    /// Invoked whenever an object is placed in on a plane.
    /// </summary>
    public static event Action onPlacedObject;

    [SerializeField]
    private UIManager m_UIManager;

    public UIManager UIManager
    {
        get { return m_UIManager; }
        set { m_UIManager = value; }
    }

    public void Place()
    {
        Debug.Log("[PlaceObjectsOnPlane] Place()");
        onPlacedObject();
    }
}
