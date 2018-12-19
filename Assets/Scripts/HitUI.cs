using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitUI : MonoBehaviour
{
    Camera camara;
    // Start is called before the first frame update
    void Start()
    {
        camara = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform cam = this.transform;
            Ray ray = new Ray(cam.position, cam.forward);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
            RaycastHit hit;
            
            if (Physics.Raycast(ray,out hit,100))
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.tag == "PuzzleParts")
                {
                    Debug.Log("entra");

                    hit.collider.gameObject.GetComponent<SpriteOnOff>().HitSprite();
                }
            }
        }
    }
}
