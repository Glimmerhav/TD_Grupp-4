using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class UpgradMenuManager : MonoBehaviour
{
    [SerializeField] float dmg = 10f, ats = 20f, critChanse = 0f, critMulti = 0f, hp = 100;
    [SerializeField] float dmgCost = 5f, atsCost = 5f, critChanseCost = 5f, critMultiCost = 5f, hpCost = 5f;
    [SerializeField] TextMeshProUGUI dmgText, atsText, critChanseText, critMultText, HPText;
    [SerializeField] TextMeshProUGUI bottenDmgText, bottenAtsText, bottenCritChanseText, bottenCritMultText, bottenHPText;
    [SerializeField] float betweenFire = 5;

    float defCrit;
    int critMultNumber;
    int critNumber = 0;
    bool didCrit= false;

    [SerializeField] Animator animator;
    bool active = false;

    [SerializeField] PlayerManager playerManager;
    [SerializeField] GameManager gameManager;

    private void Start()
    {
        Textes();
    }
    public void DMG()
    {
        dmg *= 1.2f;
        
        dmg = Mathf.Round(dmg);

    }
    public void ATS()
    {
        ats += 5;

        betweenFire = 1 / (ats * 0.01f);

    }
    
    public void HP()
    {;
        playerManager.MoreHP(1.2f);
    }

    void Textes()
    {
        dmgText.text = "Damage:" + dmg.ToString();
        
        atsText.text = "Attack/Min:" + Mathf.Round(60 / betweenFire).ToString();

        critChanseText.text = "CritC:" + defCrit.ToString("0") + critChanse.ToString("00");  

        critMultText.text = "CritMult:" + critMulti.ToString();

        HPText.text = "Life:" + playerManager.MaxHP;

        bottenAtsText.text = "cost" + atsCost;
        bottenDmgText.text = "cost" + dmgCost;
        bottenCritChanseText.text = "cost" + critChanseCost;
        bottenCritMultText.text = "cost" + critMultiCost;
        bottenHPText.text = "cost" + hpCost;
    }

    public void Menu()
    {
        if (!active) { animator.SetBool("Extend", true); active = true; }
        else if (active) { animator.SetBool("Extend", false); active = false; }
    }
    public void Crit()
    {
        critChanse += 10;
        if (critChanse >= 100) { defCrit += 1f; critChanse -= 100; }
    }
    public void CritMult()
    {
        critMulti += 0.5f;
    }
    public void CritRoller()
    {
        critNumber = 0;

        int x = Random.Range(0,101);

        if (x <= critChanse ) { critNumber += 1; }

        if (defCrit >= 1 ) { critNumber += Mathf.RoundToInt(defCrit); }

        else if(!(defCrit >= 1) && !(x <= critChanse)) { critNumber = 0; didCrit = false; }

        if(critNumber >0 ) { didCrit = true; }

        Debug.Log(critNumber);
  
    }
    public void Buy(int item)
    {
        if(item == 10) { if (gameManager.Coins >= atsCost) { gameManager.SetCoins(-atsCost); ATS(); atsCost = Mathf.Round(atsCost *= 1.4f); } }
        if(item == 20) { if (gameManager.Coins >= dmgCost) { gameManager.SetCoins(-dmgCost); DMG(); dmgCost = Mathf.Round(dmgCost *= 1.4f); } }
        if(item == 30) { if (gameManager.Coins >= critChanseCost) { gameManager.SetCoins(-critChanseCost); Crit(); critChanseCost = Mathf.Round(critChanseCost *= 1.4f); } }
        if(item == 40) { if (gameManager.Coins >= critMultiCost) { gameManager.SetCoins(-critMultiCost); CritMult(); critMultiCost = Mathf.Round(critMultiCost *= 1.4f); } }
        if(item == 50) { if (gameManager.Coins >= hpCost) { gameManager.SetCoins(-hpCost); HP(); hpCost = Mathf.Round(hpCost *= 1.4f); } }
        Textes();
    }

    public float BetweenFire { get { return betweenFire; } }
    public float Damage { get { return dmg; } }
    public float CritDMG { get { return critMulti; } }
    public int CritNumber { get { return critNumber; } }
    public bool CanCrit { get { return didCrit; } }
}
   
    
