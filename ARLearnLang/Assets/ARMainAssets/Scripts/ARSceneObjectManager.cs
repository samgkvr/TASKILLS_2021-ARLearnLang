using UnityEngine;

public class ARSceneObjectManager : MonoBehaviour
{
    public ARMainSceneManager m_ARMainSceneManager;

    [SerializeField]
    private InteractibleMenu m_InteractibleMenu;

    [SerializeField]
    private SceneCanvasObjectsManager m_SceneCanvasObjectsManager;

    public bool isEnabledInteractibleMenus;

    private int m_CurrentIDMenuVariable;

    private void Awake()
    {
        GameObject ARMainSceneManagerObject = GameObject.Find("ARMainSceneManager");
        m_ARMainSceneManager = ARMainSceneManagerObject.GetComponent<ARMainSceneManager>();
        isEnabledInteractibleMenus = true;

    }

    public void OnButtonPrevious()
    {
        //MenuVariablesObject m_MenuVariablesObject = m_InteractibleMenu.m_MenuObjects[m_CurrentIDMenuVariable]
        //    .menuVariables[m_CurrentIDMenuVariable].GetComponents<MenuVariablesObject>()[m_CurrentIDMenuVariable];

        m_CurrentIDMenuVariable--;

        //m_SceneCanvasObjectsManager.SetSceneOptions(m_MenuVariablesObject.QuestionText, m_MenuVariablesObject.AnswerText, m_MenuVariablesObject.CorrectAnswer);
    }

    public void OnButtonHome()
    {
        if (!isEnabledInteractibleMenus)
        {
            m_InteractibleMenu.ShowInteractibleMenus();
            m_SceneCanvasObjectsManager.SetActiveSceneCanvasObjects(false);
            isEnabledInteractibleMenus = true;
        }
    }

    public void OnButtonNext()
    {
        //MenuVariablesObject m_MenuVariablesObject = m_InteractibleMenu.m_MenuObjects[m_CurrentIDMenuVariable]
        //    .menuVariables[m_CurrentIDMenuVariable].GetComponents<MenuVariablesObject>()[m_CurrentIDMenuVariable];

        m_CurrentIDMenuVariable++;

        //m_SceneCanvasObjectsManager.SetSceneOptions(m_MenuVariablesObject.QuestionText, m_MenuVariablesObject.AnswerText, m_MenuVariablesObject.CorrectAnswer);
    }

    public void DisableInteractibleMenus_A(MenuVariablesObject_A m_MenuVariablesObject_A)
    {
        if (isEnabledInteractibleMenus)
        {
            m_InteractibleMenu.HideInteractibleMenus();
            m_SceneCanvasObjectsManager.SetActiveSceneCanvasObjects(true);
            isEnabledInteractibleMenus = false;

            m_CurrentIDMenuVariable = m_MenuVariablesObject_A.ID;

            m_SceneCanvasObjectsManager.SetSceneOptions(m_MenuVariablesObject_A.QuestionText, m_MenuVariablesObject_A.AnswerText, m_MenuVariablesObject_A.CorrectAnswer);
        }
    }

    public void DisableInteractibleMenus_B(MenuVariablesObject_B m_MenuVariablesObject_B)
    {
        if (isEnabledInteractibleMenus)
        {
            m_InteractibleMenu.HideInteractibleMenus();
            m_SceneCanvasObjectsManager.SetActiveSceneCanvasObjects(true);
            isEnabledInteractibleMenus = false;

            m_CurrentIDMenuVariable = m_MenuVariablesObject_B.ID;

            //m_SceneCanvasObjectsManager.SetSceneOptions(m_MenuVariablesObject_B.QuestionText, m_MenuVariablesObject_B.AnswerText, m_MenuVariablesObject_B.CorrectAnswer);
        }
    }
}
