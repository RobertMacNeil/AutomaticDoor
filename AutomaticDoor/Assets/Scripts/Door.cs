using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door;
    public float closeSpeed;
    bool open = false;
    Vector3 closing;
    Vector3 closedPosition;
    Vector3 openPosition;

    private void Start()
    {
        closing.y = -1.0f;
        closedPosition = door.transform.position;
        openPosition.y = closedPosition.y + door.transform.lossyScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (open == true)
        {
            door.transform.Translate(openPosition * Time.deltaTime);
            if (door.transform.position.y >= openPosition.y)
            {
                door.transform.position = openPosition;
            }
        }
        else if(open == false)
        {
            door.transform.Translate(closing * closeSpeed * Time.deltaTime);
            if (door.transform.position.y <= closedPosition.y)
            {
                door.transform.position = closedPosition;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        open = true;
    }

    private void OnTriggerExit(Collider other)
    {
        open = false;
    }
}
