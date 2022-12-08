using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : UIScreen
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        StartCoroutine(RestartRoutine());
    }

    public override void Init()
    {
        Restart();
    }

    IEnumerator RestartRoutine()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadSceneAsync(0);
    }
}
