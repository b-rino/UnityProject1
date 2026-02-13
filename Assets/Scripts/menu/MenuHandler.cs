using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject MainMenu;
    
    public bool isMenuOpen = false;

    public bool isPressed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CloseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (isPressed == false)
            {
                isPressed = true;
                isMenuOpen = !isMenuOpen;
                if (isMenuOpen)
                {
                    CloseMenu();
                }
                else
                {
                    OpenMenu();
                }
            }
        }
        else
        {
            isPressed = false;
        }
    }

    void CloseMenu()
    {
        Time.timeScale = 1;
        for (int i = 0; i < transform.childCount; i++) //disables all menu elements
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void OpenMenu()
    {
        Time.timeScale = 0;
        MainMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
