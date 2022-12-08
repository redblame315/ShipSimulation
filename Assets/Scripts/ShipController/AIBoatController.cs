using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBoatController : MonoBehaviour
{
    public PropellerBoats propellerBoats;
    // Start is called before the first frame update
    void Start()
    {
        propellerBoats = gameObject.GetComponent<PropellerBoats>();
    }

    // Update is called once per frame
    void Update()
    {
        propellerBoats.ThrottleUp();
        propellerBoats.SetDirection(1);
    }
}
