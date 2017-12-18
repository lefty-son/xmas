using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPat : MonoBehaviour {

    public static UIPat instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public void PatIt(){
        StartCoroutine(Pat());
    }

    IEnumerator Pat()
    {
        Debug.Log("SE");
        float time = .1f;
        float elapse = 0f;
        Vector3 rand = new Vector3(Random.Range(.75f, 1.25f), Random.Range(.75f, 1.25f), Random.Range(.75f, 1.25f));
        while (elapse <= time)
        {
            transform.localScale = Vector3.Lerp(Vector3.one, rand, elapse / time * 2f);
            elapse += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        elapse = 0f;
        while (elapse <= time)
        {
            transform.localScale = Vector3.Lerp(rand, Vector3.one, elapse / time * 2f);
            elapse += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        //      transform.localScale = Vector3.one;
    }
}
