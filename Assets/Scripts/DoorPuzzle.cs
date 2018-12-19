using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorPuzzle : MonoBehaviour
{
    int numElement;
    public GameObject[] Parts;
    public Sprite[] Runes;
    public GameObject RuneSprite, Door;
    string[,] Puzzles;
    public int numPuzzle;
    
    // Start is called before the first frame update
    void Start()
    {
        numElement = 1;
        numPuzzle = Random.Range(0,4);
        RuneSprite.GetComponent<Image>().sprite = Runes[numPuzzle];
        Puzzles = new string[4, 6];
        Puzzles[0, 0] = "Cola";
        Puzzles[0, 1] = "Garras";
        Puzzles[0, 2] = "Cabeza";
        Puzzles[0, 3] = "Alas";
        Puzzles[0, 4] = "Patas";
        Puzzles[0, 5] = "Torso";

        Puzzles[1, 0] = "Alas";
        Puzzles[1, 1] = "Torso";
        Puzzles[1, 2] = "Cabeza";
        Puzzles[1, 3] = "Cola";
        Puzzles[1, 4] = "Patas";
        Puzzles[1, 5] = "Garras";

        Puzzles[2, 0] = "Torso";
        Puzzles[2, 1] = "Cabeza";
        Puzzles[2, 2] = "Alas";
        Puzzles[2, 3] = "Garras";
        Puzzles[2, 4] = "Patas";
        Puzzles[2, 5] = "Cola";

        Puzzles[3, 0] = "Cabeza";
        Puzzles[3, 1] = "Cola";
        Puzzles[3, 2] = "Garras";
        Puzzles[3, 3] = "Alas";
        Puzzles[3, 4] = "Torso";
        Puzzles[3, 5] = "Patas";

    }

    public void newElement(GameObject NewPart)
    {
        //Debug.Log(element);
        if (numElement<6)
        {
            if (Comprobar(NewPart))
            {
                numElement++;
            }
            else
            {
                DeselectAll();
            }
        }
        else
        {
            if (Comprobar(NewPart))
            {
                Debug.Log("Opendoor");
                Door.GetComponent<OpenDoor>().StartOpenDoor();
            }
            else
            {
                DeselectAll();
            }
        }             
    }
    bool Comprobar(GameObject NewPart)
    {
        if (NewPart.name == Puzzles[numPuzzle, numElement-1])
        {
            return true;
        }
        return false;
    }
    void DeselectAll()
    {
        foreach (GameObject p in Parts)
        {
            p.GetComponent<SpriteOnOff>().Desactivate();
        }
        numElement = 1;
    }

}
