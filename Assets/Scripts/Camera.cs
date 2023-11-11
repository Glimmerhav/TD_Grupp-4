using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject rotateAround;

    private void FixedUpdate()
    {
        rotateAround.transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
