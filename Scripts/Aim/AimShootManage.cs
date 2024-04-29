using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimShootManage : MonoBehaviour
{
    [SerializeField] private PlayerAimGun playerAimGun;

    public AnimationCurve curveIdle;

    public AnimationCurve curveMovement;

    private AnimationCurve mainCurve;

    public float duration = 1f;

    public bool start = false;

    public float speedShake;

    public MainData data;

    [SerializeField] private Transform pfBullet;

    private void Start() {
        playerAimGun.OnShoot += PlayerAimGun_OnShoot;
    }

    private void Update()
    {
        if (start) 
        {
            start = false;
            Vector3 mousePosition = PlayerAimGun.GetMouseWorldPosition();
            Debug.Log(new Vector3(mousePosition.x, mousePosition.y).normalized);
            StartCoroutine(Shaking(mousePosition, mainCurve));
        }
    }

    private void PlayerAimGun_OnShoot(object sender, PlayerAimGun.OnShootEventsArgs e)
    {
        start = true;
        if (data == true)
        {
            mainCurve = curveIdle;
        }
        else if (data == false)
        {
            mainCurve = curveMovement;
        }

        Transform bulletTransform = Instantiate(pfBullet, e.gunEndPointPosition, Quaternion.identity);

        Vector3 shootDir = (e.shootPosition - e.gunEndPointPosition).normalized;
        bulletTransform.GetComponent<Bullet>().Setup(shootDir);
    }

    IEnumerator Shaking(Vector3 mousePos, AnimationCurve curve)
    {
        Vector3 startPosition = Vector3.zero;
        float elapsedTime = 0f;

        while (elapsedTime < duration / 4) 
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            Vector3 randomMovement = new Vector3(mousePos.x, mousePos.y).normalized * strength * speedShake;
            Camera.main.transform.position = Camera.main.transform.position + startPosition;
            startPosition = randomMovement;
            yield return null;
        }
    }

}

