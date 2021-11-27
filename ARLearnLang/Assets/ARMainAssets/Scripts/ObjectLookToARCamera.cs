using UnityEngine;

public class ObjectLookToARCamera : MonoBehaviour
{
    private Transform _object;
    private ARMainSceneManager ARMainSceneManager;

    private void Start()
    {
        GameObject ARMainSceneManagerObject = GameObject.Find("ARMainSceneManager");
        ARMainSceneManager = ARMainSceneManagerObject.GetComponent<ARMainSceneManager>();

        _object = ARMainSceneManager.Camera.gameObject.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(_object.transform.position);
    }
}
