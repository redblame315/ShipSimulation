using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    public UIScreen weatherUIScreen;
    public UIScreen mainUIScreen;
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
        if (string.IsNullOrEmpty(playerInfo.nickName))
            weatherUIScreen.Focus();
        else
        {
            mainUIScreen.Focus();
        }
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
