using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVFX : MonoBehaviour
{
    [SerializeField] ParticleSystem shootVFX;
    [SerializeField] Light shootLight;
    [SerializeField] float shootLightLifetime = 0.1f;

     void Awake()
    {
        shootLight.enabled = false;
    }

    public void PlayShootVFX()
    {
        shootVFX.Play();
    }

    public bool ShootVFXIsPlaying()
    {
        return shootVFX.isPlaying;
    }

    public void PlayShootLightEffect()
    {
        StartCoroutine(ShootLight());
    }

    IEnumerator ShootLight()
    {
        shootLight.enabled = true;
        yield return new WaitForSeconds(shootLightLifetime);
        shootLight.enabled = false;
    }
}
