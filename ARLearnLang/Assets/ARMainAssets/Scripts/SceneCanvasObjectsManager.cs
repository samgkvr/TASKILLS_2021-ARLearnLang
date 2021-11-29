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
    private GameObject[] sceneCanvasObject;

    [SerializeField]
    private TMP_Text[] m_QuestionText;

    [SerializeField]
    private GameObject[] m_AnswerButtonObject;

    [SerializeField]
    private TMP_Text[] m_AnswerText;

    private void Awake()
    {
        m_ARMainSceneManager = m_ARSceneObjectManager.m_ARMainSceneManager;

        for (int i = 0; i < sceneCanvas.Length; i++)
        {
            sceneCanvas[i].worldCamera = m_ARMainSceneManager.Camera;
        }
    }

    public void SetActiveSceneCanvasObjects(bool value)
    {
        for (int i = 0; i < sceneCanvasObject.Length; i++)
        {
            sceneCanvasObject[i].gameObject.SetActive(value);
        }
    }

    public void SetSceneOptions(string[] questionOptionsText, string[] answerOptionsText, int correctAnswer)
    {
        for (int i = 0; i < questionOptionsText.Length; i++)
        {
            m_QuestionText[i].text = questionOptionsText[i];
        }

        for (int i = 0; i < answerOptionsText.Length; i++)
        {
            m_AnswerText[i].text = answerOptionsText[i];
        }
    }
}
