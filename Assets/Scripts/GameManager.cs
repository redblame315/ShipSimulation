using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject player;
    [HideInInspector]
    public GameState gameState = GameState.NONE;

    private UIManager uiManager;
    [HideInInspector]
    public MainScreen mainScreen;
    public CameraOrbit orbitalCamera;
    public Light directionalLight;
    public GameObject oceanGameObject;
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

        oceanGameObject.SetActive(true);
        player = Instantiate(Resources.Load("Ships/player") as GameObject) as GameObject;
        player.transform.parent = spawnPointOfPlayer;
        player.transform.localPosition = Vector3.zero;
        player.transform.localRotation = Quaternion.identity;
        gameState = GameState.RUNNING;
        curTime = 0;
        playerInfo.energy = energyLimit;

        rainTransfrom = player.transform.Find("Rain");
        rainTransfrom.gameObject.SetActive(false);

        orbitalCamera.target = player;
        orbitalCamera.enabled = true;
        orbitalCamera.transform.parent = player.transform;
        orbitalCamera.Init();
    }

    public void AddEnergy(float addEnergy)
    {
    }

    public void InitWeather()
    {
        PropellerBoats boatController = player.GetComponent<PropellerBoats>();
        switch (OceanAdvanced.s_waveIndex)
        {
            case 0:
                rainTransfrom.gameObject.SetActive(true);
                Camera.main.clearFlags = CameraClearFlags.SolidColor;
                directionalLight.intensity = .1f;
                directionalLight.color = Color.black;                
                boatController.engine_max_rpm = 700;
                boatController.acceleration_cst = 5f;
                boatController.drag = .01f;
                break;
            case 1:
                boatController.engine_max_rpm = 1200;
                boatController.acceleration_cst = 10f;
                boatController.drag = .5f;
                break;

            case 2:
                Camera.main.clearFlags = CameraClearFlags.SolidColor;
                directionalLight.intensity = .1f;
                directionalLight.color = Color.black;

                boatController.engine_max_rpm = 1200;
                boatController.acceleration_cst = 10f;
                boatController.drag = .5f;
                break;
        }
    }
}
