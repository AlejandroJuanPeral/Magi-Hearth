using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitUI : MonoBehaviour
{
    Camera camara;
    public GameObject Crystal;
    // Start is called before the first frame update
    void Start()
    {
        camara = GetComponent<Camera>();
        Crystal.SetActive(true);
        Crystal.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl)&& Input.GetKey(KeyCode.LeftAlt))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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
                        //Crystal.GetComponent<CristalStat>().Material = hit.collider.gameObject.GetComponent<CristalStat>().Material;
                        Material m = hit.collider.gameObject.GetComponent<CristalStat>().Material;
                        Crystal.GetComponent<CristalStat>().c = hit.transform.gameObject.GetComponent<CristalStat>().c;
                        Material m2 = Crystal.GetComponentInChildren<MeshRenderer>().material;
                        m2.SetColor("_BaseColor", m.GetColor("_BaseColor"));

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
