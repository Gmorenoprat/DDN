using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmonCount : MonoBehaviour
{
    public int Life;
    public int NumberOfBull;
    public Image[] Bull;
    public Sprite FullBull;
    public Sprite EmptyBull;
    
    public Text AmmonRifle;
    public Text Granade;

    public void Update()
    {

        if (Life > NumberOfBull)
        {
            Life = NumberOfBull;
        }

        for (int i = 0; i < Bull.Length; i++)
        {
            if (i < Life)
            {
                Bull[i].sprite = FullBull;
            }
            else
            {
                Bull[i].sprite = EmptyBull;
            }
            if (i < NumberOfBull)
            {
                Bull[i].enabled = true;
            }
            else
            {
                Bull[i].enabled = false;
            }
        }
       
    }
}
