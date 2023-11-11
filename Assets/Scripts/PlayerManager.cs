using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] float maxHelthPoints = 100f;
    [SerializeField] GameObject Tower;

    float currentHP;

    Slider healthSlider;

    private void Start()
    {
        healthSlider = Tower.GetComponentInChildren<Slider>();
        currentHP = maxHelthPoints;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       healthSlider.value = (currentHP/maxHelthPoints)* 100;

        Debug.Log(healthSlider.value);
    }
}
