using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapManager : MonoBehaviour
{
    public static MapManager instance = null;
    public float fRealMapWidth = 5000;
    public float fMiniMapWidth = 100;
    public static float fWidthRate;

    public GameObject[] mapItemPrefab;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        fWidthRate = fMiniMapWidth / fRealMapWidth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateMapItem(MapObject _mapObject)
    {
        GameObject mapItemObj = Instantiate(mapItemPrefab[(int)_mapObject.mapObjectType]) as GameObject;
        mapItemObj.transform.parent = transform;
        mapItemObj.transform.localScale = Vector3.one;

        MapItem mapItem = mapItemObj.GetComponent<MapItem>();
        mapItem.targetObject = _mapObject;
        _mapObject.mapItem = mapItem;
    }

    public void SetRedarVisible(bool _visible)
    {
        MapItem[] mapItemArray = gameObject.GetComponentsInChildren<MapItem>();
        for(int i = 0; i < mapItemArray.Length; i ++)
        {
            MapItem mapItem = mapItemArray[i];
            if(mapItem.gameObject.GetComponentInChildren<UILabel>())
            {
                mapItem.transform.localScale = _visible ? Vector3.one : Vector3.zero;
            }
        }
    }

    public void SetVisible(bool _visible)
    {
        transform.localScale = _visible ? Vector3.one : Vector3.zero;
    }

    public bool GetVisible()
    {
        return transform.localScale.x == 1;
    }
}
