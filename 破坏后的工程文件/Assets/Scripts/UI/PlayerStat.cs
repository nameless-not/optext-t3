using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    public Image healthImage;

    public Image heathDelay;

    public Image powerImage;


    public void OnHealthChange(float persentage)
    {
        healthImage.fillAmount = persentage;
    }


}
