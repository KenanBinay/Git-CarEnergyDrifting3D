using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame_CoinValue : MonoBehaviour
{
    public TMPro.TextMeshProUGUI coinTxt;
    public GameObject coinSprite;
    private Vector3 endVelocity = Vector3.zero;
    [SerializeField] AnimationCurve _curve;
    bool cntrlCoin,waitDelay;
    void Start()
    {
        waitDelay = cntrlCoin = false;
    }

    private void Update()
    {
        if (cntrlCoin)
        {
            coinSprite.transform.localScale = Vector3.Lerp(Vector3.one * 112, Vector3.one * 115, _curve.Evaluate(Time.deltaTime)*Time.deltaTime);
        }
        if (waitDelay)
        {
            coinSprite.transform.localScale = Vector3.Lerp(Vector3.one * 102, Vector3.one * 102, _curve.Evaluate(Time.deltaTime)*Time.deltaTime);
        }
    }

    private void OnEnable()
    {   
        CarController.coinGained += coinIncrease;
    }

    private void OnDisable()
    {
        CarController.coinGained -= coinIncrease;
    }

    private void coinIncrease()
    {
        if (waitDelay == true) { waitDelay = false; }
        cntrlCoin = true;
        coinTxt.text = CarController.coinVal.ToString();
        StartCoroutine(delayCoinAnim());
    }

    private IEnumerator delayCoinAnim()
    {
        yield return new WaitForSeconds(0.2f);
        cntrlCoin = false;
        waitDelay = true;
    }
}
