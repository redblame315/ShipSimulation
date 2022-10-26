using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIScreen : MonoBehaviour
{
    public static GameObject previousGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void Init();
    public void Focus()
    {
        if (previousGameObject)
            previousGameObject.SetActive(false);

        gameObject.SetActive(true);
        previousGameObject = gameObject;
        Init();
    }

}
