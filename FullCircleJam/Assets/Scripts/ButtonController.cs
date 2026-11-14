using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public KeyCode KeyToPress;
    public int KeyLoop = 1;
    public KeyCode[] Keys;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // KeyToPress = Keys[KeyLoop];
        // if (Input.GetKeyDown(KeyToPress))
        // {
        //     KeyLoop += 1;
        //     if (KeyLoop > 5)
        //     {
        //         KeyLoop = 0;
        //     }
        // }
    }

    public void ChangeLoop()
    {
        KeyLoop++;
        if (KeyLoop > 5)
            KeyLoop = 0;

        KeyToPress = Keys[KeyLoop];
    }
}
