using UnityEngine;
using UnityEditor;

public class PropellerBoats : MonoBehaviour
{
    public Transform[] propellers;
    public Transform[] rudder;
    public Transform steerTrans;
    private Rigidbody rb;

    public float engine_rpm { get; private set; }
    float throttle;
    int direction = 1;

    public float propellers_constant = 0.6F;
    public float engine_max_rpm = 600.0F;
    public float acceleration_cst = 1.0F;
    public float drag = 0.01F;
    public float angle_speed = 1f;
    float angle;
    float audioEngineVolume = 0;
    AudioSource audioSource;

    void Awake()
    {
        engine_rpm = 0F;
        throttle = 0F;
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        float frame_rpm = engine_rpm * Time.deltaTime;
        for (int i = 0; i < propellers.Length; i++)
        {
            propellers[i].localRotation = Quaternion.Euler(propellers[i].localRotation.eulerAngles + new Vector3(0, 0, -frame_rpm));
            rb.AddForceAtPosition(Quaternion.Euler(0, angle, 0) * propellers[i].forward * propellers_constant * engine_rpm, propellers[i].position);
        }

        throttle *= (1.0F - drag * 0.001F);
        engine_rpm = throttle * engine_max_rpm * direction;

        angle = Mathf.Lerp(angle, 0.0F, 0.02F);
        for (int i = 0; i < rudder.Length; i++)
            rudder[i].localRotation = Quaternion.Euler(0, angle, 0);

        if(steerTrans)
            steerTrans.localRotation = Quaternion.Euler(-90, -angle, 0);        
    }

    public void ThrottleUp()
    {
        throttle += acceleration_cst * 0.001F;
        if (throttle > 1)
            throttle = 1;

        audioEngineVolume += acceleration_cst * 0.001F;
        if (audioEngineVolume > 1)
            audioEngineVolume = 1;
        if(audioSource)
            audioSource.volume = audioEngineVolume;
    }

    public void ThrottleDown()
    {
        throttle -= acceleration_cst * 0.001F;
        if (throttle < 0)
            throttle = 0;

        audioEngineVolume -= acceleration_cst * 0.001F;
        if (audioEngineVolume < 0)
            audioEngineVolume = 0;
        audioSource.volume = audioEngineVolume;
    }

    public void Brake()
    {
        throttle *= 0.9F;
    }

    public void Reverse()
    {
        direction *= -1;
    }

    public void RudderRight()
    {
        angle -= angle_speed * Time.deltaTime;        
        angle = Mathf.Clamp(angle, -90F, 90F);
    }

    public void RudderLeft()
    {
        angle += angle_speed * Time.deltaTime;
        angle = Mathf.Clamp(angle, -90F, 90F);
    }

    public void SetDirection(int _direction)
    {
        direction = _direction;
    }
    void OnDrawGizmos()
    {
        //Handles.Label(propellers[0].position, engine_rpm.ToString());
    }
}
