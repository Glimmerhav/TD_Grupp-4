using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject firePoint;
    [SerializeField] float fireRate;


    GameObject currntNearest;
    [SerializeField] UpgradMenuManager umm;
    bool canShot= true;


    // Update is called once per frame
    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layerMask);

        foreach (Collider collider in colliders)
        {
            float distance = Vector3.Distance(collider.transform.position, firePoint.transform.position);
            if (currntNearest != null)
            {
                if (distance < Vector3.Distance(currntNearest.transform.position, firePoint.transform.position))
                {
                    currntNearest = collider.gameObject;
                }
                
            }
            else
            {
                currntNearest = collider.gameObject;
            }

        }

        
        if(currntNearest != null)
        {
            if (canShot) { StartCoroutine(Shot()); }
        }
        
    }
    IEnumerator Shot()
    {
        if(TryGetComponent<LineRenderer>(out LineRenderer line))
        {
            canShot = false;
            {
                if (currntNearest.TryGetComponent<EnemyHP>(out EnemyHP enemy))
                {
                    umm.CritRoller();
                    if (!umm.CanCrit) { enemy.TakeDMG(umm.Damage); Debug.Log("did not"); }
                    else if (umm.CanCrit) { enemy.TakeDMG(umm.Damage * Mathf.Pow(umm.CritDMG, umm.CritNumber)); Debug.Log("did"); }
                    Debug.Log(umm.Damage * Mathf.Pow(umm.CritDMG, umm.CritNumber));
                }
            }
            line.SetPosition(0, new Vector3(0f, 2.5f, 0f));
            line.SetPosition(1, currntNearest.transform.position);
            yield return new WaitForSeconds(umm.BetweenFire);
            line.SetPosition(1, new Vector3(0f, 2.5f, 0f));
            canShot = true;
        }

        else
        { 
            gameObject.AddComponent<LineRenderer>();
            StartCoroutine(Shot());
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawSphere(this.transform.position, radius);


        Gizmos.color = Color.green;

        if(currntNearest == null) { return; }
        Gizmos.DrawLine(firePoint.transform.position, currntNearest.transform.position);
    }
}
