using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton<T> where T:class, new()
{
    public Singleton() { }
    private static readonly Lazy<T> instance = new Lazy<T>(()=> new T());
    public static T Instance { get { return instance.Value; } }
}

public class PlayerInfo
{
    public string nickName
    {
        get
        {
            return _nickName;
        }
        set
        {
            _nickName = value;
        }
    }

    public int playerIndex
    {
        get
        {
            return _playerIndex;
        }
        set
        {
            _playerIndex = value;
        }
    }

    public float energy
    {
        get
        {
            return _energy;
        }
        set
        {
            _energy = value;
        }
    }

    private string _nickName = "";
    private int _playerIndex = 0;
    private float _energy = 0;
    public PlayerInfo()
    {        
    }
   
    public void Save()
    {
        PlayerPrefs.SetString("nickName", _nickName);
        PlayerPrefs.SetInt("playerIndex", _playerIndex);
        PlayerPrefs.SetFloat("energy", _energy);
    }

    public void Load()
    {
        _nickName = PlayerPrefs.GetString("nickName", "");
        _playerIndex = PlayerPrefs.GetInt("playerIndex", 0);
        _energy = PlayerPrefs.GetFloat("energy", 0f);
    }
}
public enum GameState { NONE,RUNNING,WIN,LOSE}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerInfo playerInfo = new PlayerInfo();
    public Transform spawnPointOfPlayer;
    public float timeLimit;
    public float energyLimit;
    [HideInInspector]
    public float curTime = 0;
    [HideInInspector]
    public float altitude;
    [HideInInspector]
    public float curAltitude;
    [HideInInspector]
    public GameObject ship;
    [HideInInspector]
    public GameState gameState = GameState.NONE;

    private UIManager uiManager;
    [HideInInspector]
    public MainScreen mainScreen;
    public CameraOrbit orbitalCamera;
    public Light directionalLight;
    public GameObject oceanGameObject;
    public Material[] skyBoxArray;
    public GameObject[] routeObjArray;
    private Transform rainTransfrom;
    
    private void Awake()
    {
        instance = this;
        playerInfo.Load();
        playerInfo.energy = energyLimit;
    }
    // Start is called before the first frame update
    void Start()
    {
        uiManager = UIManager.instance;
        mainScreen = MainScreen.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState != GameState.RUNNING)
            return;

        /*curTime += Time.deltaTime;
        if (curTime > timeLimit)
        {
            gameState = GameState.LOSE;
            UIManager.instance.EndStage();
        }

        mainScreen.UpdateGameStateInfo();*/
            
        if(Input.GetKey(KeyCode.Escape))
        {
            playerInfo.nickName = "";
            playerInfo.Save();
            SceneManager.LoadSceneAsync(0);
        }
    }

    public void InstantiatePlayer()
    {
        if (spawnPointOfPlayer == null)
            return;

        for (int i = 0; i < routeObjArray.Length; i++)
            if(i == RouteSelectScreen.instance.routeIndex)
            {
                routeObjArray[i].SetActive(true);
                spawnPointOfPlayer = routeObjArray[i].transform.Find("StartPoint");
            }else
                routeObjArray[i].SetActive(false);

        oceanGameObject.SetActive(true);
        ship = Instantiate(Resources.Load("Ships/ship") as GameObject) as GameObject;
        Transform shipMesh = ship.transform.Find("Mesh");
        if(shipMesh)
        {
            MeshRenderer shipMeshRenderer = shipMesh.GetComponent<MeshRenderer>();
            string materialStr = ShipMaterialSelectScreen.instance.materialTypeArray[ShipMaterialSelectScreen.instance.materialIndex];
            shipMeshRenderer.sharedMaterial = Resources.Load("Materials/LCS_" + materialStr) as Material;
        }
        BoatController boatController = ship.GetComponent<BoatController>();
        ship.transform.parent = spawnPointOfPlayer;
        ship.transform.localPosition = Vector3.zero;
        ship.transform.localRotation = Quaternion.identity;
        gameState = GameState.RUNNING;
        curTime = 0;
        playerInfo.energy = energyLimit;

        rainTransfrom = ship.transform.Find("Rain");
        rainTransfrom.gameObject.SetActive(false);

        orbitalCamera.target = ship;
        orbitalCamera.enabled = true;
        orbitalCamera.transform.parent = ship.transform;
        orbitalCamera.Init();

        GameObject captainObj = Instantiate(Resources.Load("Players/player" + CharacterSelectScreen.instance.skinIndex.ToString()) as GameObject) as GameObject;       
        captainObj.transform.parent = boatController.spawnPoint;            
        captainObj.transform.localPosition = Vector3.zero;
        captainObj.transform.localRotation = Quaternion.identity;
        captainObj.transform.localScale = Vector3.one;

        CaptainCtrl captainCtrl = captainObj.GetComponent<CaptainCtrl>();
        boatController.panelCamera.headBone = captainCtrl.headBoneTrans;
        boatController.panelCamera.hero = captainObj.transform;
    }

    public void AddEnergy(float addEnergy)
    {
    }

    public void InitWeather()
    {
        PropellerBoats boatController = ship.GetComponent<PropellerBoats>();
        switch (OceanAdvanced.s_waveIndex)
        {
            case 0:
                rainTransfrom.gameObject.SetActive(true);
                //Camera.main.clearFlags = CameraClearFlags.SolidColor;
                directionalLight.intensity = .1f;
                directionalLight.color = Color.black;                
                boatController.engine_max_rpm = 3000;
                boatController.acceleration_cst = 5f;
                boatController.drag = .01f;
                RenderSettings.skybox = skyBoxArray[0];
                RenderSettings.ambientSkyColor = new Color(.3f, .3f, .3f);
                break;
            case 1:
                boatController.engine_max_rpm = 3500;
                boatController.acceleration_cst = 10f;
                boatController.drag = .5f;
                RenderSettings.skybox = skyBoxArray[1];
                RenderSettings.ambientSkyColor = Color.white;
                break;

            case 2:
                //Camera.main.clearFlags = CameraClearFlags.SolidColor;
                directionalLight.intensity = .1f;
                directionalLight.color = Color.black;

                boatController.engine_max_rpm = 3500;
                boatController.acceleration_cst = 10f;
                boatController.drag = .5f;

                RenderSettings.skybox = skyBoxArray[0];
                RenderSettings.ambientSkyColor = new Color(.3f, .3f, .3f);
                break;
        }
    }

    public void EndStage()
    {
        switch(gameState)
        {
            case GameState.WIN:
                UIManager.instance.winUIScreen.Focus();
                break;
            case GameState.LOSE:
                UIManager.instance.loseUIScreen.Focus();
                break;
        }
    }

    IEnumerator EndStageRoutine()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadSceneAsync(0);
    }
}
