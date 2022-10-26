using UnityEngine;
using System.Collections;

public class Proxies : MonoBehaviour
{
    void Awake()
    {
        Destroy(GetComponent<MeshRenderer>());
        Destroy(GetComponent<MeshFilter>());
        Destroy(this);
    }
}
