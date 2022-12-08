using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    public UIScreen characterUIScreen;
    public UIScreen shipUIScreen;
    public UIScreen routeUIScreen;
    public UIScreen weatherUIScreen;
    public UIScreen titleScreen;
    public UIScreen mainUIScreen;
    public UIScreen winUIScreen;
    public UIScreen loseUIScreen;
    private PlayerInfo playerInfo;
    private GameManager gameManager;

    private void Awake()
    {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;        
        playerInfo = GameManager.instance.playerInfo;
        characterUIScreen.Focus();
        /*if (string.IsNullOrEmpty(playerInfo.nickName))
            weatherUIScreen.Focus();
        else
        {
            mainUIScreen.Focus();
        }*/
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }    

    public void EndStage()
    {        
        Cursor.visible = true;
    }
}
