using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [SerializeField] float HP;

    [SerializeField] float dmg;

    // Update is called once per frame
    void Update()
    {
        HP = 10 * (10 * (2 + (gameManager.Minute / 5)));

        dmg = 20 * Mathf.Pow(1.4f, gameManager.Minute);
    }

    public float ToSetHP { get { return HP; } }
    public int Dmg { get { return Mathf.FloorToInt(dmg); } }
}
