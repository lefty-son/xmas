using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour {

    public static Tap instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    //public Transform[] boxDoggy;
    public BoxPat[] boxPat;

    public void TapIt(){
        StartCoroutine(Pat());
        boxPat[GameManager.instance.Index].TapIt();
    }

    public void ZeroBox(){
        boxPat[GameManager.instance.Index].done = false;
        boxPat[GameManager.instance.Index].transform.localScale = new Vector3(1f, 0.01f, 1f);
    }

    public void NextWave(){
        foreach(BoxPat bp in boxPat){
            bp.done = false;
            bp.transform.localScale = new Vector3(1f, 0.01f, 1f); 
        }
    }

    IEnumerator Pat()
    {
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
