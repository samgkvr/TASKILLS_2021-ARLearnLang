using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARMainSceneManager : MonoBehaviour
{
    public Camera Camera;

    public ARSessionOrigin ARSessionOrigin;
    public ARRaycastManager ARRaycastManager;

    void Awake()
    {
        Camera = ARSessionOrigin.camera;
    }
}
