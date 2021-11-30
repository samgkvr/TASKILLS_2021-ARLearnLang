using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARMainSceneManager : MonoBehaviour
{
    public Camera Camera;

    public ARSessionOrigin ARSessionOrigin;
    public ARRaycastManager ARRaycastManager;

    private void Awake()
    {
        Camera = ARSessionOrigin.camera;
    }
}
