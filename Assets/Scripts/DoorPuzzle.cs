using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPuzzle : MonoBehaviour
{
    int numElement;
    public GameObject[] Parts;
    string[,] Puzzles;
    int numPuzzle;
    
    // Start is called before the first frame update
    void Start()
    {
        numElement = 1;
        numPuzzle = 0;
        Puzzles = new string[1, 6];
        Puzzles[0, 0] = "Patas";
        Puzzles[0, 1] = "Garras";
        Puzzles[0, 2] = "Cabeza";
        Puzzles[0, 3] = "Alas";
        Puzzles[0, 4] = "Cola";
        Puzzles[0, 5] = "Torso";

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
                //Open door
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
