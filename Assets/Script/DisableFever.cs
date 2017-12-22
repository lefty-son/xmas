using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFever : MonoBehaviour {

    private void OnDisable()
    {
        // StartCoroutine - RewardFever
        GameManager.instance.IsRewardFever = true;
    }
}
