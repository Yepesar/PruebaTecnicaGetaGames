using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationManager : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer s_renderer;
    [SerializeField] private Material[] kartColors;
    [SerializeField] private Material[] kartPatterns;
    [SerializeField] private Transform[] wheels;

    private int selectedColor = 0;
    private int selectedPattern = 0;
    private int selectedWheel = 0;

    // Start is called before the first frame update
    void Start()
    {
        selectedWheel =  LoadData("Wheels");
        selectedPattern = LoadData("Pattern");
        selectedColor = LoadData("Color");

        SetColor(selectedColor);
        SetPattern(selectedPattern);
        SetWheel(selectedWheel);
    }

    public void SetColor(int index)
    {
        selectedColor = index;

        Material[] newMaterials = new Material[2];
        newMaterials[0] = kartPatterns[selectedPattern];
        newMaterials[1] = kartColors[selectedColor];

        s_renderer.materials = newMaterials;

        SaveData("Color", selectedColor);
    }

    public void SetPattern(int index)
    {
        selectedPattern = index;

        Material[] newMaterials = new Material[2];
        newMaterials[0] = kartPatterns[selectedPattern];
        newMaterials[1] = kartColors[selectedColor];

        s_renderer.materials = newMaterials;

        SaveData("Pattern", selectedPattern);
    }

    public void SetWheel(int index)
    {
        selectedWheel = index;

        if (selectedWheel == 0)
        {
            wheels[0].gameObject.SetActive(true);
            wheels[1].gameObject.SetActive(false);
            wheels[2].gameObject.SetActive(false);
        }
        else if (selectedWheel == 1)
        {
            wheels[0].gameObject.SetActive(false);
            wheels[1].gameObject.SetActive(true);
            wheels[2].gameObject.SetActive(false);
        }
        else if (selectedWheel == 2)
        {
            wheels[0].gameObject.SetActive(false);
            wheels[1].gameObject.SetActive(false);
            wheels[2].gameObject.SetActive(true);
        }

        SaveData("Wheels", selectedWheel);
    }

    private void SaveData(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    private int LoadData(string key)
    {
        int value;
        value = PlayerPrefs.GetInt(key);
        return value;
    }
}
