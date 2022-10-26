using UnityEngine;
using System.Collections;

public class SplashGenerator : MonoBehaviour
{
  public Vector3 offset;

  private OceanAdvanced ocean;
  private Vector3 last_position;
  private float speed;

  void Awake()
  {
    ocean = FindObjectOfType<OceanAdvanced>();
    speed = 0.0F;
    last_position = transform.position;
    InvokeRepeating("CheckSplash", 0.1F, 0.2F);
  }

  void CheckSplash()
  {
    speed = (transform.position - last_position).magnitude / 0.5F;
    if (speed < 3F)
      return;
    Vector3 p = transform.position + transform.rotation * offset;
    float h = OceanAdvanced.GetWaterHeight(p);

    if (p.y < h && last_position.y > h && speed > 2.0F)
      ocean.RegisterInteraction(p, Mathf.Clamp01(speed / 15.0F) * 0.5F);

    last_position = transform.position;
  }

  void OnDrawGizmos()
  {
    Gizmos.color = Color.cyan;
    Gizmos.DrawWireSphere(transform.position + transform.rotation * offset, 1F);
  }
}
