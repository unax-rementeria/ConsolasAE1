using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FirstSelect : MonoBehaviour
{
    public List<Button> listButton;


    void FixedUpdate()
    {
        for (int i = 0; i < listButton.Count; i++)
        {
            if (EventSystem.current.currentSelectedGameObject == listButton[i].gameObject)
            {
                Debug.Log("Selected Button");
                break;
            }else if (listButton[listButton.Count - 1].gameObject != EventSystem.current.currentSelectedGameObject)
            {
                Debug.Log("Not Selected Button");
                listButton[0].Select();
            }
        }

    }

    void Start()
    {
        //listButton[0] = GetComponent<Button>();
        listButton[0].Select();
    }
    void deselected()
    {
        listButton[0].Select();
    }
}
