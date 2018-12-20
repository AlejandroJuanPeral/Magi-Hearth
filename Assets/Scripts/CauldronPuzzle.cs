using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CauldronPuzzle : MonoBehaviour
{
    int numElement;
    public GameObject[] Crystals;
    public Sprite[] Runes;
    public GameObject RuneSprite;
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
        RuneSprite.GetComponent<Image>().sprite = Runes[numPuzzle];
        material = GetComponent<MeshRenderer>().material;
        material.SetColor("_BaseColor", Color.black);
        Color PuzzleColor = Color.Lerp(Color.red, Color.white,1f/2);
        PuzzleColor = Color.Lerp(PuzzleColor, Color.yellow, 1f / 3);
        PuzzleColor = Color.Lerp(PuzzleColor, Color.blue, 1f / 4);
        solutions[0] = PuzzleColor;
        PuzzleColor = Color.Lerp(Color.red, Color.blue, 1f / 2);
        PuzzleColor = Color.Lerp(PuzzleColor, Color.yellow, 1f / 3);
        PuzzleColor = Color.Lerp(PuzzleColor, Color.blue, 1f / 4);
        solutions[1] = PuzzleColor;
        PuzzleColor = Color.Lerp(Color.red, Color.yellow, 1f / 2);
        PuzzleColor = Color.Lerp(PuzzleColor, Color.white, 1f / 3);
        PuzzleColor = Color.Lerp(PuzzleColor, Color.blue, 1f / 4);
        solutions[2] = PuzzleColor;
        PuzzleColor = Color.Lerp(Color.black, Color.white, 1f / 2);
        PuzzleColor = Color.Lerp(PuzzleColor, Color.red, 1f / 3);
        PuzzleColor = Color.Lerp(PuzzleColor, Color.blue, 1f / 4);
        solutions[3] = PuzzleColor;

    }

    // Update is called once per frame



    public void NewCrystal(Material m)
    {
        Debug.Log(numElement);

        if (numElement > 1&& numElement <4)
        {
            //Debug.Log("Color1" + material.GetColor("_BaseColor") + "color2" + m.GetColor("_BaseColor"));
            waterColor = Color.Lerp(material.GetColor("_BaseColor"), m.GetColor("_BaseColor"), 1f / numElement);
            numElement++;
            material.SetColor("_BaseColor", waterColor);

        }
        else if (numElement == 4)
        {
            waterColor = Color.Lerp(material.GetColor("_BaseColor"), m.GetColor("_BaseColor"), 1f / numElement);
            material.SetColor("_BaseColor", waterColor);
            Compare();
        }
        else
        {
            waterColor = m.GetColor("_BaseColor");
            numElement++;
            material.SetColor("_BaseColor", waterColor);

        }
        // Debug.Log(waterColor);

    }
    void Compare()
    {
        if(material.GetColor("_BaseColor") == solutions[numPuzzle])
        {
            Debug.Log("Complete");
        }
        else
        {
            Restart();
        }
    }
    void Restart()
    {
        foreach (GameObject c in Crystals)
        {
            Debug.Log("...");
            c.SetActive(true);
        }
        material.SetColor("_BaseColor", Color.black);
        numElement = 1;
    }
}
