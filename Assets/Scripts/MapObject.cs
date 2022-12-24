using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapObjectType { Hero, StartPoint, EndPoint, NavPoint, Obstacle}
public class MapObject : MonoBehaviour
{
    public MapObjectType mapObjectType = MapObjectType.Hero;
    [HideInInspector]
    public MapItem mapItem;
    [HideInInspector]
    public bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        MapManager.instance.InstantiateMapItem(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
