using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectScreen : UIScreen
{
    public static CharacterSelectScreen instance = null;
    public GameObject characterSelectObj;
    public UILabel skinTypeLabel;
    public string[] skinTypeArray;
    public GameObject[] characterObjArray;
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
        skinTypeLabel.text = skinTypeArray[skinIndex];

        shipControl.ShipController.Select.performed += ctx => CharacterScreenNextButtonClicked();
        shipControl.ShipController.Left.performed += ctx => SkinPrevButtonClicked();
        shipControl.ShipController.Right.performed += ctx => SkinNextButtonClicked();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CharacterSkinSelectButtonClicked()
    {
        skinIndex++;
        if (skinIndex == skinTypeArray.Length)
            skinIndex = 0;

        skinTypeLabel.text = skinTypeArray[skinIndex];
        for (int i = 0; i < characterObjArray.Length; i++)
            characterObjArray[i].SetActive(i == skinIndex);
    }

    public void SkinPrevButtonClicked()
    {
        skinIndex--;
        if (skinIndex < 0)
            skinIndex = 0;

        skinTypeLabel.text = skinTypeArray[skinIndex];
        for (int i = 0; i < characterObjArray.Length; i++)
            characterObjArray[i].SetActive(i == skinIndex);
    }

    public void SkinNextButtonClicked()
    {
        skinIndex++;
        if (skinIndex >= skinTypeArray.Length)
        {
            skinIndex = skinTypeArray.Length - 1;
        }

        skinTypeLabel.text = skinTypeArray[skinIndex];
        for (int i = 0; i < characterObjArray.Length; i++)
            characterObjArray[i].SetActive(i == skinIndex);
    }
    public void CharacterScreenNextButtonClicked()
    {
        characterSelectObj.SetActive(false);
        UIManager.instance.shipUIScreen.Focus();
    }
    public override void Init()
    {
        characterSelectObj.SetActive(true);
        if (GameManager.instance.ship != null)
            Destroy(GameManager.instance.ship);
    }

    private void OnEnable()
    {
        //Singleton<ShipControl>.Instance.ShipController.Enable();
        shipControl.Enable();
    }

    private void OnDisable()
    {
        //Singleton<ShipControl>.Instance.ShipController.Disable();
        shipControl.Disable();
        if(characterSelectObj)
            characterSelectObj.SetActive(false);
    }
}
