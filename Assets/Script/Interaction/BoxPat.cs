using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPat : MonoBehaviour {
    public bool done;
    private bool doing = false;

    public void TapIt(float _value){
        if(!done){
            if(GameManager.instance.IsRewardFever){
                transform.localScale += new Vector3(0f, _value * PrefManager.instance.GetSantaCalc() * 1.5f, 0f); 
            }
            else {
                transform.localScale += new Vector3(0f, _value * PrefManager.instance.GetSantaCalc(), 0f); 
            }
            //  tapping as value X user's power
            StartCoroutine(Pat());
        }
    }

    IEnumerator Pat()
    {
        if(doing){
            yield return null;
        } else {
            FeverSlider.instance.SliderUp();
            doing = true;

            float time = .1f;
            float elapse = 0f;

            Vector3 rand = new Vector3(Random.Range(.75f, 1.25f), transform.localScale.y, Random.Range(.75f, 1.25f));

            var origin = transform.localScale;
            while (elapse <= time)
            {
                transform.localScale = Vector3.Lerp(origin, rand, elapse / time * 2f);
                elapse += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            doing = false;

            if (transform.localScale.y >= 1f)
            {
                done = true;
                GiftSpawner.instance.ConveyorOut();
                GameManager.instance.Stack++;
            }
        }

    }
}
