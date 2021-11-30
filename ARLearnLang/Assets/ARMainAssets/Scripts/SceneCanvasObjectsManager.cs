using UnityEngine;
using TMPro;

public class SceneCanvasObjectsManager : MonoBehaviour
{
    [SerializeField]
    private ARSceneObjectManager m_ARSceneObjectManager;

    private ARMainSceneManager m_ARMainSceneManager;

    [SerializeField]
    private Canvas[] sceneCanvas;

    [SerializeField]
    private GameObject sceneCanvasObject;

    public GameObject[] ModuleObjects;

    public int m_CurrentSceneID;

    private int m_correctAnswer;

    [SerializeField]
    private TMP_Text TextNumberScene;

    private void Awake()
    {
        m_ARMainSceneManager = m_ARSceneObjectManager.m_ARMainSceneManager;

        for (int i = 0; i < sceneCanvas.Length; i++)
        {
            sceneCanvas[i].worldCamera = m_ARMainSceneManager.Camera;
        }

        if (!sceneCanvasObject.activeSelf)
        {
            sceneCanvasObject.gameObject.SetActive(false);
        }

        for (int i = 0; i < ModuleObjects.Length; i++)
        {
            if (!ModuleObjects[i].activeSelf)
            {
                ModuleObjects[i].gameObject.SetActive(false);
            }
        }
    }

    public void SetActiveSceneCanvasObject(bool value)
    {
        sceneCanvasObject.gameObject.SetActive(value);
        DisableALLScene();
    }

    public void ButtonAnswer(int idButton)
    {
        if (idButton == m_correctAnswer)
        {
            Debug.Log("Answer true");
            m_ARSceneObjectManager.OnButtonNext();
        }
        else
        {
            Debug.Log("Answer false, try again");
        }
    }

    public void TriggerAnswerModuleA(bool isRight)
    {
        if (isRight)
        {
            ChangeScene(m_CurrentSceneID + 1);
        }
    }

    public void TriggerAnswerModuleB(int IDScene)
    {
        SceneBCInputFieldManager m_SceneBCInputFieldManager = ModuleObjects[IDScene].GetComponent<SceneBCInputFieldManager>();
        if (m_SceneBCInputFieldManager.InputField.text == m_SceneBCInputFieldManager.AnswerText)
        {
            ChangeScene(m_CurrentSceneID + 1);
        }
    }

    public void ChangeScene(int IDScene)
    {
        TextNumberScene.text = "Модуль: " + ModuleObjects[IDScene].name;
        for (int i = 0; i < ModuleObjects.Length; i++)
        {
            if (ModuleObjects[i] != ModuleObjects[IDScene])
            {
                ModuleObjects[i].SetActive(false);
            }
            else
            {
                m_CurrentSceneID = IDScene;
                ModuleObjects[IDScene].SetActive(true);
            }
        }
    }

    private void DisableALLScene()
    {
        for (int i = 0; i < ModuleObjects.Length; i++)
        {
            m_CurrentSceneID = -1;
            ModuleObjects[i].SetActive(false);
        }
    }
}
