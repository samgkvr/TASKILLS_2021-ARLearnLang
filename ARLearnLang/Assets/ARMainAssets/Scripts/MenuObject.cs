using UnityEngine;

public class MenuObject : MonoBehaviour
{
    public bool scalingFinish;
    public Transform startPos, mainPos, selectPos;

    [SerializeField]
    private GameObject[] menuVariablesPos;

    private float _velocity = 2f;
    private bool isMove;
    private bool isMoveSelect;

    public bool stateSelected;

    private Vector3 scaleChange;

    private bool menuVariablesIsEnable;
    private bool menuVariablesIsMove; // future

    [SerializeField]
    public GameObject[] menuVariables;

    private void Awake()
    {
        scaleChange = new Vector3(0.05f, 0.05f, 0.05f);
    }

    public void MoveStart()
    {
        if (!isMove)
        {
            isMove = true;
            isMoveSelect = false;
            menuVariablesIsEnable = true;
        }
    }

    public void MoveSelect()
    {
        if (!isMoveSelect)
        {
            isMove = false;
            isMoveSelect = true;
            menuVariablesIsEnable = true;
            //menuVariables[0].
        }
    }

    private void FixedUpdate()
    {
        if (isMove)
        {
            if (transform.position != mainPos.position || transform.localScale.y >= 1.0f)
            {
                if (transform.localScale.y > 1.0f)
                {
                    transform.localScale -= scaleChange;
                }
                transform.position = Vector3.MoveTowards(transform.position, mainPos.position, Time.deltaTime * _velocity);
            }
            else
            {
                isMove = false;
                stateSelected = false;
            }
        }
        else if (isMoveSelect)
        {
            if (transform.position != selectPos.position || transform.localScale.y <= 1.5f)
            {
                if (transform.localScale.y < 1.5f)
                {
                    transform.localScale += scaleChange;
                }
                transform.position = Vector3.MoveTowards(transform.position, selectPos.position, Time.deltaTime * _velocity);
            }
            else
            {
                isMoveSelect = false;
                stateSelected = true;
            }
        }

        if (menuVariablesIsEnable)
        {
            if (isMove)
            {
                menuVariablesOn(false);
                menuVariablesIsMove = true;
                menuVariablesIsEnable = false;
            }
            else if (isMoveSelect)
            {
                menuVariablesOn(true);
                menuVariablesIsMove = true;
                menuVariablesIsEnable = false;
            }
        }
    }

    private void menuVariablesOn(bool setActiveVariables)
    {
        switch (menuVariables.Length)
        {
            case 1:
                menuVariables[0].transform.position = menuVariablesPos[2].transform.position;
                menuVariables[0].SetActive(setActiveVariables);
                break;
            case 2:
                menuVariables[0].transform.position = menuVariablesPos[1].transform.position;
                menuVariables[1].transform.position = menuVariablesPos[3].transform.position;
                menuVariables[0].SetActive(setActiveVariables);
                menuVariables[1].SetActive(setActiveVariables);
                break;
            case 3:
                menuVariables[0].transform.position = menuVariablesPos[0].transform.position;
                menuVariables[1].transform.position = menuVariablesPos[2].transform.position;
                menuVariables[2].transform.position = menuVariablesPos[4].transform.position;
                menuVariables[0].SetActive(setActiveVariables);
                menuVariables[1].SetActive(setActiveVariables);
                menuVariables[2].SetActive(setActiveVariables);
                break;
            case 4:
                menuVariables[0].transform.position = menuVariablesPos[0].transform.position;
                menuVariables[1].transform.position = menuVariablesPos[1].transform.position;
                menuVariables[2].transform.position = menuVariablesPos[3].transform.position;
                menuVariables[3].transform.position = menuVariablesPos[4].transform.position;
                menuVariables[0].SetActive(setActiveVariables);
                menuVariables[1].SetActive(setActiveVariables);
                menuVariables[2].SetActive(setActiveVariables);
                menuVariables[3].SetActive(setActiveVariables);
                break;
        }
    }
}
