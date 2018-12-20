using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CauldronPuzzle : MonoBehaviour
{
    int numElement;
    public GameObject[] Crystals;
    public Sprite[] Runes;
    public GameObject RuneSprite, Portal;
    string[,] Puzzles;
    public int numPuzzle;
    Material material;
    Color waterColor;
    Color[] solutions = new Color[4];
    
    // Start is called before the first frame update
    void Start()
    {
        numElement = 1;
        numPuzzle = Random.Range(0, 4);
       // RuneSprite.GetComponent<Image>().sprite = Runes[numPuzzle];
        material = GetComponentInChildren<MeshRenderer>().material;
        material.SetColor("_BaseColor", Color.black);
        //solutions[0] = ;
        //solutions[1] = ;
        //solutions[2] = ;
        //solutions[3] = ;

    }

    // Update is called once per frame



    public void NewCrystal(Material m)
    {

        if (numElement > 1)
        {
            waterColor = Color.Lerp(material.GetColor("_BaseColor"), m.GetColor("_BaseColor"), numElement);
            numElement++;
        }else if (numElement == 4)
        {
            waterColor = Color.Lerp(material.GetColor("_BaseColor"), m.GetColor("_BaseColor"), numElement);
            Compare();
        }
        else
        {

            waterColor = m.GetColor("_BaseColor");
        }
        material.SetColor("_BaseColor", waterColor);

    }
    void Compare()
    {
        /*if(material.GetColor("_BaseColor") == solutions[numPuzzle])
        {
            //complete
        }
        else
        {
            Restart();
            material.SetColor("_BaseColor", Color.black);
        }*/
    }
    void Restart()
    {
        foreach (GameObject c in Crystals)
        {
            c.SetActive(true);
        }
    }
}
