using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool open = false;
    float startTime, currentTime;
    Vector3 now, end; 

    // Start is called before the first frame update
    void Start()
    {
        end = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);

    }
    public void StartOpenDoor()
    {
        open = true;
        startTime = Time.time;
        currentTime = startTime;
    }

    // Update is called once per frame

    void Update()
    {
        if (open)
        {
            now = transform.position;
            currentTime += Time.deltaTime;
            transform.position = Vector3.Slerp(now, end, (currentTime - startTime)/6);
        }
 
    }
}
