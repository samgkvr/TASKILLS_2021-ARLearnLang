using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DisableTrackedVisuals : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Disables spawned feature points and the ARPointCloudManager")]
    private bool m_DisableFeaturePoints;

    public bool disableFeaturePoints
    {
        get => m_DisableFeaturePoints;
        set => m_DisableFeaturePoints = value;
    }

    [SerializeField]
    [Tooltip("Disables spawned planes and ARPlaneManager")]
    private bool m_DisablePlaneRendering;

    public bool disablePlaneRendering
    {
        get => m_DisablePlaneRendering;
        set => m_DisablePlaneRendering = value;
    }

    [SerializeField]
    private ARPointCloudManager m_PointCloudManager;

    public ARPointCloudManager pointCloudManager
    {
        get => m_PointCloudManager;
        set => m_PointCloudManager = value;
    }

    [SerializeField]
    private ARPlaneManager m_PlaneManager;

    public ARPlaneManager planeManager
    {
        get => m_PlaneManager;
        set => m_PlaneManager = value;
    }

    private void OnEnable()
    {
        PlaceObjectsOnPlane.onPlacedObject += OnPlacedObject;
    }

    private void OnDisable()
    {
        PlaceObjectsOnPlane.onPlacedObject -= OnPlacedObject;
    }

    private void OnPlacedObject()
    {
        if (m_DisableFeaturePoints)
        {
            m_PointCloudManager.SetTrackablesActive(false);
            m_PointCloudManager.enabled = false;
        }

        if (m_DisablePlaneRendering)
        {
            m_PlaneManager.SetTrackablesActive(false);
            m_PlaneManager.enabled = false;
        }
    }
}
