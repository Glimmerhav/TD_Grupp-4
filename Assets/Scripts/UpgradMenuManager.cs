using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class UpgradMenuManager : MonoBehaviour
{
    [SerializeField] float dmg = 10f, ats = 20f, critChanse = 0f, critMulti = 0f, hp = 100;
    [SerializeField] TextMeshProUGUI dmgText, atsText, critChanseText, critMultText, HPText;
    [SerializeField] float betweenFire = 5;


    private void Start()
    {
        Textes();
    }
    public void DMG()
    {
        dmg *= 1.2f;
        
        dmg = Mathf.Round(dmg);

        Textes();
    }
    public void ATS()
    {
        ats += 5;

        betweenFire = 1 / (ats * 0.01f);

        Textes();

    }

    void Textes()
    {
        dmgText.text = "Damage:" + dmg.ToString();
        
        atsText.text = "Attack/Min:" + Mathf.Round(60 / betweenFire).ToString();
    }

    public float BetweenFire {get{ return betweenFire; } }
}
   
    
