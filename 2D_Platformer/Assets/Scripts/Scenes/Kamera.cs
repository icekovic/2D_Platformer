using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{

    [SerializeField]
    private GameObject igrac;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - igrac.transform.position;
    }

    void LateUpdate()
    {
        transform.position = igrac.transform.position + offset;
    }
}
