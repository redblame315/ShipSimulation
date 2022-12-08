using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteSelectScreen : UIScreen
{
    public static RouteSelectScreen instance = null;
    public UILabel routeLabel;
    public string[] routeStringArray;
    public GameObject[] routeObjArray;
    [HideInInspector]
    public int routeIndex = 0;
    ShipControl shipControl;
    private void Awake()
    {
        instance = this;
        shipControl = new ShipControl();
    }
    // Start is called before the first frame update
    void Start()
    {
        routeLabel.text = routeStringArray[routeIndex];

        shipControl.ShipController.Select.performed += ctx => NextButtonClicked();
        shipControl.ShipController.Back.performed += ctx => PrevButtonClicked();
        shipControl.ShipController.Left.performed += ctx => RoutePrevButtonClicked();
        shipControl.ShipController.Right.performed += ctx => RouteNextButtonClicked();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RouteSelectButtonClicked()
    {
        routeIndex++;
        if (routeIndex == routeStringArray.Length)
        {
            routeIndex = 0;
        }

        routeLabel.text = routeStringArray[routeIndex];
        for (int i = 0; i < routeObjArray.Length; i++)
            routeObjArray[i].SetActive(i == routeIndex);
    }

    public void RoutePrevButtonClicked()
    {
        routeIndex--;
        if (routeIndex < 0)
            routeIndex = 0;

        routeLabel.text = routeStringArray[routeIndex];
        for (int i = 0; i < routeObjArray.Length; i++)
            routeObjArray[i].SetActive(i == routeIndex);
    }

    public void RouteNextButtonClicked()
    {
        routeIndex++;
        if (routeIndex >= routeStringArray.Length)
        {
            routeIndex = routeStringArray.Length - 1;
        }

        routeLabel.text = routeStringArray[routeIndex];
        for (int i = 0; i < routeObjArray.Length; i++)
            routeObjArray[i].SetActive(i == routeIndex);
    }
    public void NextButtonClicked()
    {
        UIManager.instance.weatherUIScreen.Focus();
    }

    public void PrevButtonClicked()
    {
        UIManager.instance.shipUIScreen.Focus();
    }

    public override void Init()
    {
        
    }

    private void OnEnable()
    {
        shipControl.Enable();             
    }

    private void OnDisable()
    {
        shipControl.Disable();
    }
}
