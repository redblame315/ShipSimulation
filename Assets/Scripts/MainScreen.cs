using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreen : UIScreen
{
    public static MainScreen instance = null;
    public UILabel nickNameLabel;
    public UISprite heroSprite;
    public UIProgressBar energyProgressBar;
    public UISprite timerSprite;
    public UILabel timerLabel;
    public UISlider altitudeSlider;
    public UILabel altitudeLabel;
    public UILabel curAltitudeLabel;

    GameManager gameManager;
    PlayerInfo playerInfo;

    private void Awake()
    {
        instance = this;
    }
    public override void Init()
    {
        gameManager = GameManager.instance;
        playerInfo = gameManager.playerInfo;
        gameManager.mainScreen = this;
        gameManager.InstantiatePlayer();
        gameManager.InitWeather();

    }

    public void UpdatePlayerInfoUI()
    {
    }

    public void UpdateGameStateInfo()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
