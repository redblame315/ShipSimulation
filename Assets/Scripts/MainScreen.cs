using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CameraMode
{
    HeroFirstPerson,
    HeroThirdPerson,
    ShipTirdPerson
}
public class ShipSetting
{
    public float countdown;

    public ShipSetting()
    {

    }
}

public class MainScreen : UIScreen
{
    public static MainScreen instance = null;
    public UIPopupList cameramPopupList;
    public UIToggle navToggle;
    public UIToggle redarToggle;
    public UIToggle engineStartToggle;
    public UIToggle engineStopToggle;
    public UIToggle fowardToggle;
    public UIToggle backwardToggle;
    public UIToggle brakeToggle;
    public UIToggle cameraModeFPCToggle;
    public UIToggle cameraModeTPC1Toggle;
    public UIToggle cameraModeTPC2Toggle;
    public UISprite navPointSuccessSprite;
    public UISprite engineStateSprite;
    public UILabel engineGuideLabel;
    public UILabel countDownLabel;
    public GameObject warningUIObj;
    public float timeLimit = 60;
    public float addTimeAmount = 5;
    float curTime;
    int cameraModeIndex = 0;

    public ShipControl shipControl;
    GameManager gameManager;
    PlayerInfo playerInfo;

    private void Awake()
    {
        instance = this;
        shipControl = new ShipControl();
    }
    public override void Init()
    {
        gameManager = GameManager.instance;
        playerInfo = gameManager.playerInfo;
        gameManager.mainScreen = this;

        ReadSettingFile();
        curTime = timeLimit;

        MapManager.instance.SetVisible(true);
        gameManager.InstantiatePlayer();
        gameManager.InitWeather();
    }

    public void ReadSettingFile()
    {
        string path = "setting.txt";
        if (!File.Exists(path))
            return;

        StreamReader reader = new StreamReader(path);
        string settingText = reader.ReadToEnd();
        ShipSetting shipSetting = JsonUtility.FromJson<ShipSetting>(settingText);
        timeLimit = shipSetting.countdown;
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
        shipControl.ShipController.Back.performed += ctx => BackButtonClicked();
        shipControl.ShipController.Map.performed += ctx => NavMapButtonClicked();
        shipControl.ShipController.EngineStart.performed += ctx => EngineStartButtonClicked();
        shipControl.ShipController.EngeineStop.performed += ctx => EngineStopButtonClicked();
        shipControl.ShipController.CameraAngle.performed += ctx => CameraViewButtonClicked();
        shipControl.ShipController.Forward.performed += ctx => DirectionForwardButtonClicked();
        shipControl.ShipController.Backward.performed += ctx => DirectionBackwardButtonClicked();
        shipControl.ShipController.Brake.performed += ctx => DirectionStopButtonClicked();
    }

    public void BackButtonClicked()
    {
        StopAllCoroutines();
        SceneManager.LoadSceneAsync(0);
    }


    // Update is called once per frame
    void Update()
    {
        curTime -= Time.deltaTime;
        if(curTime < 0)
        {
            GameManager.instance.gameState = GameState.LOSE;
            GameManager.instance.EndStage();
            return;
        }
        countDownLabel.text = string.Format("{0:0.00}", curTime);
        
        /*if (Input.GetKey(KeyCode.B))
            SelectButtonClicked();
        else if(Input.GetKeyUp(KeyCode.F))
        {
            navToggle.isChecked = !navToggle.isChecked;
            NavMapButtonClicked();
        }else if(Input.GetKeyUp(KeyCode.G))
        {
            engineStartToggle.isChecked = true;
            EngineStartButtonClicked();
        }
        else if (Input.GetKeyUp(KeyCode.H))
        {
            engineStopToggle.isChecked = true;
            EngineStopButtonClicked();
        }
        else if (Input.GetKeyUp(KeyCode.I))
        {
            cameraModeIndex++;
            if (cameraModeIndex == 3)
                cameraModeIndex = 0;
            
            switch(cameraModeIndex)
            {
                case 0:
                    cameraModeFPCToggle.isChecked = true;
                    FirstCameraButtonClicked();
                    break;
                case 1:
                    cameraModeTPC1Toggle.isChecked = true;
                    SecondCameraButtonClicked();
                    break;
                case 2:
                    cameraModeTPC2Toggle.isChecked = true;
                    ThirdCameramButtonClicked();
                    break;
            }
        }
        else if (Input.GetKeyUp(KeyCode.J))
        {
            fowardToggle.isChecked = true;
            DirectionForwardButtonClicked();
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            brakeToggle.isChecked = true;
            DirectionStopButtonClicked();
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            backwardToggle.isChecked = true;
            DirectionBackwardButtonClicked();
        }*/
    }

    public void CameraViewButtonClicked()
    {
        cameraModeIndex++;
        if (cameraModeIndex == 3)
            cameraModeIndex = 0;

        switch (cameraModeIndex)
        {
            case 0:
                cameraModeFPCToggle.isChecked = true;
                FirstCameraButtonClicked();
                break;
            case 1:
                cameraModeTPC1Toggle.isChecked = true;
                SecondCameraButtonClicked();
                break;
            case 2:
                cameraModeTPC2Toggle.isChecked = true;
                ThirdCameramButtonClicked();
                break;
        }
    }

    public void FirstCameraButtonClicked()
    {
        SetCameraMode(CameraMode.HeroFirstPerson);
    }

    public void SecondCameraButtonClicked()
    {
        SetCameraMode(CameraMode.HeroThirdPerson);
    }

    public void ThirdCameramButtonClicked()
    {
        SetCameraMode(CameraMode.ShipTirdPerson);
    }

    public void SetCameraMode(CameraMode cameraMode)
    {
        if (HeroCamera.instance == null)
            return;

        switch(cameraMode)
        {
            case CameraMode.HeroFirstPerson:
                HeroCamera.instance.SetCamerState(HeroCamera.CameraState.FirstPerson);
                BoatController.instance.panelCamera.gameObject.SetActive(true);
                break;
            case CameraMode.HeroThirdPerson:
                HeroCamera.instance.SetCamerState(HeroCamera.CameraState.ThirdPerson);
                BoatController.instance.panelCamera.gameObject.SetActive(true);
                break;
            case CameraMode.ShipTirdPerson:
                BoatController.instance.panelCamera.gameObject.SetActive(false);
                break;
        }
    }

    //B7 : 
    public void EngineStartButtonClicked()
    {
        engineStartToggle.isChecked = true;
        engineStateSprite.color = Color.green;
        engineGuideLabel.gameObject.SetActive(false);
        BoatController.instance.boatControlInput.engineState = 1;
    }

    //B8 :
    public void EngineStopButtonClicked()
    {
        engineStopToggle.isChecked = true;
        engineStateSprite.color = Color.black;
        engineGuideLabel.gameObject.SetActive(true);
        BoatController.instance.boatControlInput.engineState = 0;
    }

    public void DirectionForwardButtonClicked()
    {
        fowardToggle.isChecked = true;
        BoatController.instance.boatControlInput.direction = 1;
    }

    public void DirectionStopButtonClicked()
    {
        brakeToggle.isChecked = true;
        BoatController.instance.boatControlInput.direction = 0;
    }

    public void DirectionBackwardButtonClicked()
    {
        backwardToggle.isChecked = true;
        BoatController.instance.boatControlInput.direction = -1;
    }

    public void CameraOptionValueChanged()
    {
        if (cameramPopupList.value == "FPC")
            FirstCameraButtonClicked();
        else if (cameramPopupList.value == "TPC1")
            SecondCameraButtonClicked();
        else
            ThirdCameramButtonClicked();
    }

    public void NavMapButtonClicked()
    {
        navToggle.isChecked = !navToggle.isChecked;
        MapManager.instance.SetVisible(navToggle.isChecked);
    }

    public void RedarToggleButtonClicked()
    {
        MapManager.instance.SetRedarVisible(redarToggle.isChecked);
    }

    public void EscapeButtonClicked()
    {
        Application.Quit();
    }

    //B2 : B
    public void SelectButtonClicked()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ChecksNavPointSuccess()
    {
        navPointSuccessSprite.transform.localScale = Vector3.zero;
        navPointSuccessSprite.color = new Color(255,255,255,255);

        TweenScale tweenScale = navPointSuccessSprite.GetComponent<TweenScale>();
        TweenAlpha tweenAlpha = navPointSuccessSprite.GetComponent<TweenAlpha>();
        tweenScale.ResetToBeginning();
        tweenAlpha.ResetToBeginning();
        tweenScale.PlayForward();

        AddTime();
    }

    public void AddTime(bool b_Add = true)
    {
        if (gameManager.gameState != GameState.RUNNING)
            return;

        if(b_Add)
            curTime += addTimeAmount;
        else
            curTime -= addTimeAmount;
    }

    private void OnEnable()
    {
        shipControl.Enable();
    }

    private void OnDisable()
    {
        shipControl.Disable();
    }

    private void OnDestroy()
    {
        shipControl.Disable();
    }
}
