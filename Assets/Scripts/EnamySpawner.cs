using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnamySpawner : MonoBehaviour
{
    [SerializeField] GameObject Enemys;
    [SerializeField] GameObject parent;
    [SerializeField] float MinRadius, MaxRadius, rateBetween;
    float timer;
    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if(timer >= rateBetween)
        {
            timer = 0;

            Vector2 point = Random.insideUnitCircle.normalized * Random.Range(MinRadius, MaxRadius);
            Instantiate(Enemys, new Vector3(point.x, 0, point.y), Quaternion.identity, parent.transform);
        }

    }
}
