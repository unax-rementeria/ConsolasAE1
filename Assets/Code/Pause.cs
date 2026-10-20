using UnityEngine;
using UnityEngine.InputSystem;



public class Pause : MonoBehaviour
{
    private InputSystem_Actions inputActions;
    public bool isPaused = false;
    public GameObject pauseMenu;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        pauseMenu.SetActive(false);
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        if (inputActions.Car.Pause.triggered) // COMO CONIO HAGO PARA QUE DETECTE LA DESCONEXION DEL MANDO????? (ToT) 
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f; // Pause the game
            Debug.Log("Game Paused");
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
            Debug.Log("Game Resumed");
        }
    }
}
