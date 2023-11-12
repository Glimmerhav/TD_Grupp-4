using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] float StartingHP = 100f;
    [SerializeField] float maxHelthPoints;
    [SerializeField] GameObject Tower;
    [SerializeField] TextMeshProUGUI Hptext;

    float currentHP;

    bool canTakeDmg = true;

    Slider healthSlider;

    [SerializeField] EnemyManager enemyManager;

    private void Awake()
    {
        healthSlider = Tower.GetComponentInChildren<Slider>();
        currentHP = StartingHP;
        maxHelthPoints = StartingHP;
    }
    public void MoreHP(float multi)
    {
        currentHP = Mathf.Round(currentHP* multi);
        maxHelthPoints = Mathf.Round(maxHelthPoints * multi);

        if (currentHP >= maxHelthPoints ) { currentHP = maxHelthPoints; }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        healthSlider.value = (currentHP/maxHelthPoints)* 100;

        Hptext.text = currentHP + "/" + maxHelthPoints;

        Debug.Log(canTakeDmg);

        if(currentHP <= 0) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
    }
    public IEnumerator DmgCyckel()
    {
        if (canTakeDmg) 
        {
            canTakeDmg = false;
            currentHP -= enemyManager.Dmg;
            yield return new WaitForSeconds(1.5f);
            canTakeDmg = true;
        }
        yield return new WaitForSeconds(0);
    }

    public float MaxHP { get { return maxHelthPoints; } }
    public bool CanTakeDmg { get {  return canTakeDmg; } }

    
}
