using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;
using UnityEngine.VR;
public class ShootingGunController : MonoBehaviour
{
    public AudioSource audioSource;
    public VRInput vrInput;//需先在上面標註使用VRStandardAssets.Utils; 才能用VRInput
    public ParticleSystem flareParticle;
    public LineRenderer gunFlare;
    public Transform gunEnd;
    public float defaultLineLength= 70f;
    public float gunFlareVisibleSeconds = 0.07f;
    private void OnEnable()
    {
        vrInput.OnDown += HandleDown;
    }
    private void OnDisable()
    {
        vrInput.OnDown -= HandleDown;
    }

    private void HandleDown()
    {
        
        StartCoroutine(Fire());//可先跳過往下走
        
    }

    private IEnumerator Fire()
    {
        audioSource.Play();
        float lineLength = defaultLineLength;

        flareParticle.Play();
        gunFlare.enabled = true;
        yield return StartCoroutine(MoveLineRenderer(lineLength));//先暫停此方法先等到某步驟完成
        gunFlare.enabled = false;
    }

    private IEnumerator MoveLineRenderer(float lineLength)
    {
        float timer = 0f;
        while (timer < gunFlareVisibleSeconds)
        {
            gunFlare.SetPosition(0, gunEnd.position);
            gunFlare.SetPosition(1, gunEnd.position+ gunEnd.forward * lineLength);
            yield return null;
            timer += Time.deltaTime;
        }
    }
}
