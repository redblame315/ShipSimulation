using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationPoint : MonoBehaviour
{
    public NavigationPoint nextNavPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        MainScreen.instance.ChecksNavPointSuccess();
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
