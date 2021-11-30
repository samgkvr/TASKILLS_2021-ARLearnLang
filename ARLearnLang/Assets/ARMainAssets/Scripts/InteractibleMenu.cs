using UnityEngine;

public class InteractibleMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_Menu;

    public MenuObject[] m_MenuObjects;

    private Vector3 scaleStart;
    private Vector3 scaleChange;

    [SerializeField]
    private ARSceneObjectManager m_ARSceneObjectManager;

    private ARMainSceneManager m_ARMainSceneManager;

    private GameObject touchedObject;
    private bool touchBegan = false;

    private void Awake()
    {
        m_ARMainSceneManager = m_ARSceneObjectManager.m_ARMainSceneManager;

        scaleStart = new Vector3(0.1f, 0.1f, 0.1f);
        scaleChange = new Vector3(0.05f, 0.05f, 0.05f);

        m_MenuObjects = new MenuObject[m_Menu.Length];

        for (int i = 0; i < m_Menu.Length; i++)
        {
            m_MenuObjects[i] = m_Menu[i].GetComponent<MenuObject>();
        }

        for (int i = 0; i < m_Menu.Length; i++)
        {
            m_Menu[i].transform.localScale = scaleStart;
        }

    }

    private void FixedUpdate()
    {
        if (!m_MenuObjects[0].scalingFinish)
        {
            MenuScale(m_Menu[0], m_MenuObjects[0]);
        }
        if (m_MenuObjects[0].scalingFinish && !m_MenuObjects[1].scalingFinish)
        {
            MenuScale(m_Menu[1], m_MenuObjects[1]);
        }
        if (m_MenuObjects[1].scalingFinish && !m_MenuObjects[2].scalingFinish)
        {
            MenuScale(m_Menu[2], m_MenuObjects[2]);
        }
        //if (m_MenuObjects[2].scalingFinish && !m_MenuObjects[3].scalingFinish)
        //{
        //    MenuScale(m_Menu[3], m_MenuObjects[3]);
        //}

        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && !touchBegan)
            {
                touchBegan = true;
                Ray ray = m_ARMainSceneManager.Camera.ScreenPointToRay(Input.GetTouch(0).position);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider != null)
                    {
                        touchedObject = hit.transform.gameObject;
                        Debug.Log("Touched " + touchedObject.transform.name);

                        if (touchedObject.GetComponent<MenuObject>())
                        {
                            SelectedMenu(touchedObject.GetComponent<MenuObject>(), m_MenuObjects);
                        }

                        if (touchedObject.GetComponent<MenuVariablesObject>())
                        {
                            m_ARSceneObjectManager.DisableInteractibleMenus(touchedObject.GetComponent<MenuVariablesObject>().IDScene);
                        }
                    }
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended && touchBegan)
            {
                touchBegan = false;
            }
        }
    }

    public void HideInteractibleMenus()
    {
        for (int i = 0; i < m_MenuObjects.Length; i++)
        {
            m_MenuObjects[i].gameObject.SetActive(false);
        }
    }

    public void ShowInteractibleMenus()
    {
        for (int i = 0; i < m_MenuObjects.Length; i++)
        {
            m_MenuObjects[i].gameObject.SetActive(true);
        }
    }

    //m_MenuObjects[0].MoveSelect();
    private void SelectedMenu(MenuObject SelectObject, MenuObject[] StartObjects)
    {
        if (SelectObject.stateSelected)
        {
            SelectObject.MoveStart();
        }
        else
        {
            for (int i = 0; i < StartObjects.Length; i++)
            {
                if (StartObjects[i] != SelectObject)
                {
                    StartObjects[i].MoveStart();
                }
                else
                {
                    SelectObject.MoveSelect();
                }
            }
        }
    }

    private void MenuScale(GameObject menu, MenuObject menuObject)
    {
        if (!menu.activeSelf)
        {
            menu.SetActive(true);
        }

        if (menu.transform.localScale.y >= 1.25f)
        {
            menuObject.scalingFinish = true;
        }

        if (menuObject.scalingFinish)
        {
            if (menu.transform.localScale.y > 1.0f)
            {
                menu.transform.localScale -= scaleChange;
            }
        }
        else
        {
            if (menu.transform.localScale.y < 1.25f)
            {
                menu.transform.localScale += scaleChange;
            }
        }
    }
}
