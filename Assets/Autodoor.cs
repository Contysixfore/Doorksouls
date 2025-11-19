using System.Runtime.CompilerServices;
using UnityEngine;

public class Autodoor : MonoBehaviour
{
    public enum DoorState
    {
        Closed,
        Closing,
        Open,
        Opening,
    }
    DoorState State;
    public float Duration = 1.0f;
    public GameObject Hinge;
    float Timeline;

    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case DoorState.Opening:
                Hinge.transform.Rotate(0, 90.0f / Duration * Time.deltaTime, 0);
                Timeline -= Time.deltaTime;
                if (Timeline <= 0.0f)
                {
                    State = DoorState.Open;
                }
                break;
            default:
                // DO NOTHNG
                break;
            case DoorState.Closing:
                Hinge.transform.Rotate(0, -90.0f / Duration * Time.deltaTime, 0);
                Timeline -= Time.deltaTime;
                if (Timeline <= 0.0f)
                {
                    State = DoorState.Closed;
                }
                break;

        }

    }
    private void OnTriggerExit(Collider other)
    {
        switch (State)
        {
            case DoorState.Open:
                Debug.Log("Closing!");
                Timeline = Duration;
                State = DoorState.Closing;

                break;
            default:
                //IGNORE TRIGGER ENTER
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (State)
        {
            case DoorState.Closed:
                Debug.Log("Opening!");
                Timeline = Duration;
                State = DoorState.Opening;

                break;
            default:
                //IGNORE TRIGGER ENTER
                break;
        }
    }
}

