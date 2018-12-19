using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteOnOff : MonoBehaviour
{
    public Sprite SpriteOn, SpriteOff;
    bool activate;
    public GameObject Puzzle;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = SpriteOff;
        activate = false;
    }

    public void Desactivate()
    {
        GetComponent<Image>().sprite = SpriteOff;
        activate = false;
    }
    
    public void HitSprite()
    {
        if (!activate)
        {
            GetComponent<Image>().sprite = SpriteOn;
            activate = true;
            Puzzle.GetComponent<DoorPuzzle>().newElement(this.gameObject);
        }
    }
}
