using UnityEngine;

public class ARSceneObjectManager : MonoBehaviour
{
    public ARMainSceneManager m_ARMainSceneManager;

    [SerializeField]
    private InteractibleMenu m_InteractibleMenu;

    [SerializeField]
    private SceneCanvasObjectsManager m_SceneCanvasObjectsManager;

    public bool isEnabledInteractibleMenus;

    private void Awake()
    {
        GameObject ARMainSceneManagerObject = GameObject.Find("ARMainSceneManager");
        m_ARMainSceneManager = ARMainSceneManagerObject.GetComponent<ARMainSceneManager>();
        isEnabledInteractibleMenus = true;

    }

    public void OnButtonPrevious()
    {
        m_SceneCanvasObjectsManager.ChangeScene(m_SceneCanvasObjectsManager.m_CurrentSceneID - 1);
    }

    public void OnButtonHome()
    {
        if (!isEnabledInteractibleMenus)
        {
            m_InteractibleMenu.ShowInteractibleMenus();
            m_SceneCanvasObjectsManager.SetActiveSceneCanvasObject(false);
            isEnabledInteractibleMenus = true;
        }
    }

    public void OnButtonNext()
    {
        m_SceneCanvasObjectsManager.ChangeScene(m_SceneCanvasObjectsManager.m_CurrentSceneID + 1);
    }

    public void DisableInteractibleMenus(int IDScene)
    {
        if (isEnabledInteractibleMenus)
        {
            m_InteractibleMenu.HideInteractibleMenus();
            m_SceneCanvasObjectsManager.SetActiveSceneCanvasObject(true);
            isEnabledInteractibleMenus = false;
            m_SceneCanvasObjectsManager.ChangeScene(IDScene);
        }
    }
}
