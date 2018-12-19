using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitUI : MonoBehaviour
{
    Camera camara;
    public GameObject Crystal;
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
                else if(hit.transform.tag == "Crystals")
                {
                    if (!Crystal.activeSelf)
                    {
                        hit.transform.gameObject.SetActive(false);
                        Crystal.SetActive(true);
                        Crystal.GetComponent<CristalStat>().c = hit.transform.gameObject.GetComponent<CristalStat>().c;
                        Crystal.GetComponent<CristalStat>().material =hit.collider.gameObject.GetComponent<CristalStat>().material;
                        //Material m = hit.collider.gameObject.GetComponent<CristalStat>().Material;
                        //Crystal.GetComponent<CristalStat>().Material.SetColor("_BaseColor",/*m.GetColor("_BaseColor")*/Color.gray);
                    }
                }
                else if(hit.transform.tag == "Liquid")
                {
                    if (Crystal.activeSelf)
                    {
                        Crystal.GetComponent<CristalStat>().SetInCauldron(hit.transform.gameObject);
                        Crystal.SetActive(false);
                    }
                }
            }
        }
    }
}
