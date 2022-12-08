using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItem : MonoBehaviour
{
    [HideInInspector]
    public MapObject targetObject;

    public bool bSyncRotation = true;
    Transform targetTransform;
    UILabel distanceLabel;
    // Start is called before the first frame update
    void Start()
    {
        distanceLabel = gameObject.GetComponentInChildren<UILabel>();
        targetTransform = targetObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = targetTransform.position;
        Vector3 itemPos = new Vector3(targetPos.x * MapManager.fWidthRate, targetPos.z * MapManager.fWidthRate, 0);

        transform.localPosition = itemPos;

        if(bSyncRotation)
        {
            Vector3 targetRotation = targetTransform.eulerAngles;
            Vector3 itemRotation = new Vector3(0, 0, -targetRotation.y);

            transform.localEulerAngles = itemRotation;
        }

        if(distanceLabel != null)
        {
            float distance = Vector3.Distance(targetTransform.position, BoatController.instance.transform.position);
            distanceLabel.text = string.Format("{0:0,0.00}M", distance);
        }
    }
}
