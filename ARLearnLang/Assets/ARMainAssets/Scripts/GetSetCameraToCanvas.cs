using UnityEngine;

public class GetSetCameraToCanvas : MonoBehaviour
{
    private ARMainSceneManager m_ARMainSceneManager;
    [SerializeField]
    private Canvas[] canv;

    private void Awake()
    {
        GameObject ARMainSceneManagerObject = GameObject.Find("ARMainSceneManager");
        m_ARMainSceneManager = ARMainSceneManagerObject.GetComponent<ARMainSceneManager>();

        for (int i = 0; i < canv.Length; i++)
        {
            canv[i].worldCamera = m_ARMainSceneManager.Camera;
        }
    }
}
