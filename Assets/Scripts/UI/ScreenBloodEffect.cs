using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenBloodEffect : MonoBehaviour
{
    [SerializeField] Image bloodyScreenImage;

    public bool IsDamageTaken { get; set; }

    PlayerSFX _playerSFX;

    void Awake()
    {
        bloodyScreenImage.enabled = false;
        _playerSFX = FindObjectOfType<PlayerSFX>();
    }

    void Update()
    {
        if (IsDamageTaken)
        {
            StartCoroutine(ApplyBloodyScreen());
        }
    }

    IEnumerator ApplyBloodyScreen()
    {
        bloodyScreenImage.enabled = true;
        IsDamageTaken = false;
        _playerSFX.PlayHurtSFX();

        for (float i = 1; i > 0; i -= Time.deltaTime)
        {
            bloodyScreenImage.color = new Color(255, 255, 255, i);
            yield return null;
        }

        bloodyScreenImage.enabled = false;
    }

}
