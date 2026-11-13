using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public KeyCode KeyToPress;
    public int KeyLoop = 0;
    public KeyCode[] Keys;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        KeyToPress = Keys[KeyLoop];
        if (Input.GetKeyDown(KeyToPress))
        {
            Debug.Log("poo");
            KeyLoop += 1;
            if (KeyLoop > 5)
            {
                KeyLoop = 0;
            }
        }
    }
}
