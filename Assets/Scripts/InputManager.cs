using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public InputActionAsset controls;
    public InputAction moveAction;
    public InputAction fireAction;

    // Singleton pattern
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        moveAction = controls.FindAction("Move");
        fireAction = controls.FindAction("Fire");
        moveAction.Enable();
        fireAction.Enable();
    }
}
