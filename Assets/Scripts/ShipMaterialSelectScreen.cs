using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMaterialSelectScreen : UIScreen
{
    public static ShipMaterialSelectScreen instance = null;
    public GameObject shipObj;
    public UILabel materialTypeLabel;
    public string[] materialTypeArray;
    public Material[] materialObjArray;
    [HideInInspector]
    public int materialIndex = 0;

    private MeshRenderer shipMeshRender;
    ShipControl shipControl;
    private void Awake()
    {
        instance = this;
        shipControl = new ShipControl();
    }
    // Start is called before the first frame update
    void Start()
    {
        materialTypeLabel.text = materialTypeArray[materialIndex];
        shipMeshRender = shipObj.GetComponentInChildren<MeshRenderer>();

        shipControl.ShipController.Select.performed += ctx => ShipScreenNextButtonClicked();
        shipControl.ShipController.Back.performed += ctx => ShipScreenPrevButtonClicked();
        shipControl.ShipController.Left.performed += ctx => SkinPrevButtonClicked();
        shipControl.ShipController.Right.performed += ctx => SkinNextButtonClicked();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShipSkinSelectButtonClicked()
    {
        materialIndex ++;
        if (materialIndex == materialTypeArray.Length)
            materialIndex = 0;

        materialTypeLabel.text = materialTypeArray[materialIndex];
        shipMeshRender.sharedMaterial = materialObjArray[materialIndex];
        shipMeshRender.materials[0] = materialObjArray[materialIndex];
    }

    public void SkinPrevButtonClicked()
    {
        materialIndex--;
        if (materialIndex < 0)
            materialIndex = 0;

        materialTypeLabel.text = materialTypeArray[materialIndex];
        shipMeshRender.sharedMaterial = materialObjArray[materialIndex];
        shipMeshRender.materials[0] = materialObjArray[materialIndex];
    }

    public void SkinNextButtonClicked()
    {
        materialIndex++;
        if (materialIndex >= materialTypeArray.Length)
        {
            materialIndex = materialTypeArray.Length - 1;
        }

        materialTypeLabel.text = materialTypeArray[materialIndex];
        shipMeshRender.sharedMaterial = materialObjArray[materialIndex];
        shipMeshRender.materials[0] = materialObjArray[materialIndex];
    }
    public void ShipScreenNextButtonClicked()
    {
        shipObj.SetActive(false);
        UIManager.instance.routeUIScreen.Focus();
    
    }
    public void ShipScreenPrevButtonClicked()
    {
        shipObj.SetActive(false);
        UIManager.instance.characterUIScreen.Focus();
    }
    public override void Init()
    {
        shipObj.SetActive(true);
        if (GameManager.instance.ship != null)
            Destroy(GameManager.instance.ship);       
    }

    private void OnEnable()
    {
        shipControl.Enable();
    }

    private void OnDisable()
    {
        shipObj.SetActive(false);
        shipControl.Disable();
    }
}
