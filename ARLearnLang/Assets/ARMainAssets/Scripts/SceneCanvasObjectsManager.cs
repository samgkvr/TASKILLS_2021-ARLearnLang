using System.Collections;
using TMPro;
using UnityEngine;

public class SceneCanvasObjectsManager : MonoBehaviour
{
    [SerializeField]
    private ARSceneObjectManager m_ARSceneObjectManager;

    private ARMainSceneManager m_ARMainSceneManager;

    [SerializeField]
    private GameObject sceneCanvasObject;

    public GameObject[] ModuleObjects;

    public int m_CurrentSceneID;

    [SerializeField]
    private TMP_Text TextAnswerScene;

    [SerializeField]
    private TMP_Text TextNumberScene;

    [SerializeField]
    private GameObject WinObject;

    private void Awake()
    {
        TextAnswerScene.text = "";
        TextAnswerScene.color = Color.white;

        m_ARMainSceneManager = m_ARSceneObjectManager.m_ARMainSceneManager;

        for (int i = 0; i < ModuleObjects.Length; i++)
        {
            for (int b = 0; b < ModuleObjects[i].GetComponent<SceneModuleObject>().LocalCanvas.Length; b++)
            {
                ModuleObjects[i].GetComponent<SceneModuleObject>().LocalCanvas[b].worldCamera = m_ARMainSceneManager.Camera;
            }
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

    public void TriggerAnswerModuleA(bool isRight)
    {
        if (isRight)
        {
            SpawnWin();
            TextAnswerScene.text = "Поздравляем!";
            TextAnswerScene.color = Color.green;
            StartCoroutine(TimerChangeScene(m_CurrentSceneID + 1));
        }
        else
        {
            TextAnswerScene.text = "Вы неверно ответили на вопрос";
            TextAnswerScene.color = Color.red;
        }
    }

    public void TriggerAnswerModuleB(int IDScene)
    {
        SceneBCInputFieldManager m_SceneBCInputFieldManager = ModuleObjects[IDScene].GetComponent<SceneBCInputFieldManager>();
        if (m_SceneBCInputFieldManager.InputField.text == m_SceneBCInputFieldManager.AnswerText)
        {
            SpawnWin();
            TextAnswerScene.text = "Поздравляем!";
            TextAnswerScene.color = Color.green;
            StartCoroutine(TimerChangeScene(m_CurrentSceneID + 1));
        }
        else
        {
            TextAnswerScene.text = "Вы неверно ответили на вопрос";
            TextAnswerScene.color = Color.red;
        }
    }

    public void ChangeScene(int IDScene)
    {
        TextAnswerScene.text = "";
        TextAnswerScene.color = Color.white;
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

    private void SpawnWin()
    {
        GameObject temp = Instantiate(WinObject, new Vector3(0, 1, 1), Quaternion.identity);
        Destroy(temp, 5);
    }

    private IEnumerator TimerChangeScene(int IDScene)
    {
        yield return new WaitForSeconds(5);
        ChangeScene(IDScene);
        StopCoroutine("TimerChangeScene");
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
