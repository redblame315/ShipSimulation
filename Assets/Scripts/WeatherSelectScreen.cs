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

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        weatherTypeLabel.text = skinTypeArray[skinIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public override void Init()
    {
        if (GameManager.instance.player != null)
            Destroy(GameManager.instance.player);
    }    
}
