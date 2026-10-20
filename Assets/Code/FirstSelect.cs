using UnityEngine;
using UnityEngine.UI;

public class FirstSelect : MonoBehaviour
{
    Button firstButton;

    void OnEnable()
    {
        firstButton = GetComponent<Button>();
        firstButton.Select();
    }
}
