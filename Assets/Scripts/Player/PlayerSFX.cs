using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] AudioClip shotgunSFX;
    [SerializeField] AudioClip hurtSFX;

    public void PlayShotgunSFX()
    {
        AudioSource.PlayClipAtPoint(shotgunSFX, Camera.main.transform.position);
    }

    public void PlayHurtSFX()
    {
        AudioSource.PlayClipAtPoint(hurtSFX, Camera.main.transform.position);
    }
}
