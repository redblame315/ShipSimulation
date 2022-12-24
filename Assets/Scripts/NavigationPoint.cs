using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationPoint : MonoBehaviour
{
    public NavigationPoint nextNavPoint;
    public bool bRotateCamera = true;
    public MapObject[] obstacleArray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!bRotateCamera)
            return;
        Vector3 dir = BoatController.instance.transform.position - transform.position;
        dir.y = 0;
        dir.Normalize();
        Quaternion navRotation = Quaternion.LookRotation(dir);
        Vector3 eulerAngles = transform.eulerAngles;
        transform.eulerAngles = new Vector3(eulerAngles.x, navRotation.eulerAngles.y, eulerAngles.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.gameState != GameState.RUNNING || other.tag != "Player")
            return;

        bRotateCamera = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (GameManager.instance.gameState != GameState.RUNNING || other.tag != "Player")
            return;

        MainScreen.instance.ChecksNavPointSuccess();

        //Get non-hit obstacle count and add timer
        int obstacleCount = 0;
        for (int i = 0; i < obstacleArray.Length; i++)
            if (!obstacleArray[i].isHit)
                obstacleCount++;

        MainScreen.instance.ChecksObstacleSuccess(obstacleCount);

        MapObject mapObject = gameObject.GetComponentInChildren<MapObject>();
       
        if(mapObject)
        {
            if (mapObject.mapObjectType == MapObjectType.EndPoint)
            {
                GameManager.instance.gameState = GameState.WIN;
                GameManager.instance.EndStage();
            }
                

            Destroy(mapObject.mapItem.gameObject);
        }

        SoundManager.instance.PlayEffectSound(EffectSound.CheckNavPoint);

        if(nextNavPoint)
            nextNavPoint.gameObject.SetActive(true);

        Destroy(gameObject);
    }
}
