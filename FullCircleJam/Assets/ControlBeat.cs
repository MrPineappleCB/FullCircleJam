using UnityEngine;

public class ControlBeat : MonoBehaviour
{

    public float Tempo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Tempo /= 60f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(Tempo*Time.deltaTime, 0f, 0f);
    }
}
