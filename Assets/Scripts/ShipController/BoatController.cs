using UnityEngine;
using System.Collections;

public class BoatControlInput
{
    public int engineState = 0; //1:engine start, 0:engine stop
    public int direction = 0; //1:forward, 0:stop, -1:backward
    public BoatControlInput()
    { 
    }
}

public class BoatController : MonoBehaviour
{
    public static BoatController instance = null;
    public PropellerBoats ship;
    bool forward = true;
    public Transform spawnPoint;
    public HeroCamera panelCamera;
    public BoatControlInput boatControlInput = new BoatControlInput();
    ShipControl shipControl;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        shipControl = MainScreen.instance.shipControl;
    }
    void Update()
    {
        if (GameManager.instance.gameState != GameState.RUNNING)
            return;

        if (Input.GetKeyDown(KeyCode.P))
        {
            panelCamera.gameObject.SetActive(!panelCamera.gameObject.active);
        }

        if(shipControl.ShipController.Right.IsPressed())
            ship.RudderRight();

        if (shipControl.ShipController.Left.IsPressed())
            ship.RudderLeft();
        /*if (Input.GetKey(KeyCode.C))
            ship.RudderLeft();
        if (Input.GetKey(KeyCode.D))
            ship.RudderRight();*/

        switch (boatControlInput.engineState)
        {
            case 0:
                ship.ThrottleDown();
                break;
            case 1:
                ship.ThrottleUp();
                break;
        }

        switch(boatControlInput.direction)
        {
            case 1:
                ship.SetDirection(boatControlInput.direction);
                break;
            case 0:
                ship.Brake();
                break;
            case -1:
                ship.SetDirection(boatControlInput.direction);
                break;
        }
        /*if (forward)
        {
            if (Input.GetKey(KeyCode.W))
                ship.ThrottleUp();
            else if (Input.GetKey(KeyCode.S))
            {
                ship.ThrottleDown();
                ship.Brake();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.S))
                ship.ThrottleUp();
            else if (Input.GetKey(KeyCode.W))
            {
                ship.ThrottleDown();
                ship.Brake();
            }
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            ship.ThrottleDown();

        if (ship.engine_rpm == 0 && Input.GetKeyDown(KeyCode.S) && forward)
        {
            forward = false;
            ship.Reverse();
        }
        else if (ship.engine_rpm == 0 && Input.GetKeyDown(KeyCode.W) && !forward)
        {
            forward = true;
            ship.Reverse();
        }*/
    }
}
