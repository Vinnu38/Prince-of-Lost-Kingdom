using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    [SerializeField]Slider slider;
    public void SetmaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }    
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
