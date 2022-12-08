using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherSelectScreen : UIScreen
{
    public static WeatherSelectScreen instance = null;
    public UISprite weathersprite;
    public UILabel weatherTypeLabel;
    public string[] skinTypeArray;
    public string[] weatherSpriteNameArray;
    [HideInInspector]
    public int skinIndex = 0;
    ShipControl shipControl;
    private void Awake()
    {
        instance = this;
        shipControl = new ShipControl();
    }
    // Start is called before the first frame update
    void Start()
    {
        weatherTypeLabel.text = skinTypeArray[skinIndex];

        shipControl.ShipController.Select.performed += ctx => NextButtonClicked();
        shipControl.ShipController.Back.performed += ctx => PrevButtonClicked();
        shipControl.ShipController.Left.performed += ctx => SkinPrevButtonClicked();
        shipControl.ShipController.Right.performed += ctx => SkinNextButtonClicked();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WeatherSelectButtonClicked()
    {
        skinIndex++;
        if (skinIndex == skinTypeArray.Length)
        {
            skinIndex = 0;
        }

        weatherTypeLabel.text = skinTypeArray[skinIndex];
        weathersprite.spriteName = weatherSpriteNameArray[skinIndex];
    }

    public void SkinPrevButtonClicked()
    {
        skinIndex--;
        if (skinIndex < 0)
            skinIndex = 0;

        weatherTypeLabel.text = skinTypeArray[skinIndex];
        weathersprite.spriteName = weatherSpriteNameArray[skinIndex];
    }

    public void SkinNextButtonClicked()
    {
        skinIndex++;
        if (skinIndex >= skinTypeArray.Length)
        {
            skinIndex = skinTypeArray.Length - 1;
        }

        weatherTypeLabel.text = skinTypeArray[skinIndex];
        weathersprite.spriteName = weatherSpriteNameArray[skinIndex];
    }

    public void NextButtonClicked()
    {
        OceanAdvanced.s_waveIndex = skinIndex;
        UIManager.instance.mainUIScreen.Focus();
    }

    public void PrevButtonClicked()
    {
        UIManager.instance.routeUIScreen.Focus();
    }

    public override void Init()
    {
        if (GameManager.instance.ship != null)
            Destroy(GameManager.instance.ship);
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
