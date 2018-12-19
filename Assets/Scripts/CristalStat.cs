using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalStat : MonoBehaviour
{
    public enum EnumColor { Yellow, Red, Blue, White, Black };
    public EnumColor c;
    Color crystalColor;
    public Material material;

   /* public Material Material
    {
        get
        {
            return material;
        }

        set
        {
            material = value;
        }
    }*/
    private void Start()
    {
        material = GetComponentInChildren<MeshRenderer>().material;
        switch (c)
        {
            case EnumColor.Yellow:
                crystalColor = Color.yellow;
                break;
            case EnumColor.Red:
                crystalColor = Color.red;
                break;
            case EnumColor.Blue:
                crystalColor = Color.blue;
                break;
            case EnumColor.White:
                crystalColor = Color.white;
                break;
            case EnumColor.Black:
                crystalColor = Color.black;
                break;

        }
        material.SetColor("_BaseColor", crystalColor);
    }
    public void SetInCauldron(GameObject cauldron)
    {
        cauldron.GetComponent<CauldronPuzzle>().NewCrystal(material);
        
    }
    public void UpdateColor(Color color)
    {
        material.SetColor("_BaseColor", color);
    }

}
