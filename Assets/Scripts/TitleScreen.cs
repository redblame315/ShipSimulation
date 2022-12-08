using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TitleScreen : UIScreen
{
    public static TitleScreen instance = null;
    public VideoPlayer videoPlayerObj;
    public GameObject splashObject;
    ShipControl shipControl;
    private void Awake()
    {
        instance = this;
    }

    public override void Init()
    {
        PlaySplashVideo();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();

        shipControl = new ShipControl();
        shipControl.ShipController.Right.performed += ctx => NextButtonClicked();
        shipControl.ShipController.Left.performed += ctx => NextButtonClicked();
        shipControl.ShipController.EngineStart.performed += ctx => NextButtonClicked();
        shipControl.ShipController.EngeineStop.performed += ctx => NextButtonClicked();
        shipControl.ShipController.Back.performed += ctx => NextButtonClicked();
        shipControl.ShipController.Map.performed += ctx => NextButtonClicked();
        shipControl.ShipController.Select.performed += ctx => NextButtonClicked();
        shipControl.Enable();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlaySplashVideo()
    {
        AudioSource audioSource = videoPlayerObj.gameObject.AddComponent<AudioSource>();
        videoPlayerObj.SetTargetAudioSource(0, audioSource);
        videoPlayerObj.EnableAudioTrack(0, true);
        videoPlayerObj.controlledAudioTrackCount = 1;
        videoPlayerObj.Play();
        videoPlayerObj.waitForFirstFrame = true;
        videoPlayerObj.gameObject.SetActive(true);
        StartCoroutine(ShowVideoTexture());
    }

    IEnumerator ShowVideoTexture()
    {
        yield return new WaitForSeconds(.5f);
        splashObject.SetActive(true);
    }

    public void NextButtonClicked()
    {
        //videoPlayerObj.SetActive(false);
        //UIManager.instance.characterUIScreen.Focus();
        shipControl.Disable();
        SceneManager.LoadSceneAsync(1);
    }

}
