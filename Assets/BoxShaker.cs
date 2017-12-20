using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxShaker : MonoBehaviour {

    static int heartNumber;
    public static BoxShaker instance;
    public GameObject hurray;
    private Image boxImg;
    public Button keepGoin;
    public Animation parentAnim;
    public AnimationClip parentIn, parentOut;
    public GameObject[] hearts;
    public GameObject fader;

    private void Awake()
    {
        if (instance == null) instance = this;
        boxImg = GetComponent<Image>();
        keepGoin.onClick.AddListener(KeepGoing);
        keepGoin.gameObject.SetActive(false);

    }

    private void OnEnable()
    {
        foreach(GameObject go in hearts){
            go.SetActive(false);
        }
        parentAnim.transform.localScale = Vector3.one;
        boxImg.transform.localScale = Vector3.one;
        parentAnim.GetComponent<RectTransform>().offsetMin = new Vector2(800, 0);
        parentAnim.GetComponent<RectTransform>().offsetMax = new Vector2(800, 0);
        Shake();
    }

    public void Shake(){
        StartCoroutine(Shaking());
    }

    IEnumerator Shaking(){
        keepGoin.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        var t = 0f;

        while (t <= 2f)
        {
            Vector3 rand = new Vector3(Random.Range(.75f, 1.25f), Random.Range(.75f, 1.25f), Random.Range(.75f, 1.25f));
            transform.localScale = Vector3.Lerp(Vector3.one, rand, t / 2f);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        boxImg.transform.localScale = Vector3.zero;
        var r = Random.Range(0, 3);
        heartNumber = r;
        keepGoin.gameObject.SetActive(true);
        hearts[r].SetActive(true);

        fader.SetActive(true);
        hurray.SetActive(true);
   
    }

    private void OnDisable()
    {
        GameManager.instance.EarnHeart(heartNumber + 1);
        hurray.SetActive(false);
    }

    public void KeepGoing(){
        parentAnim.clip = parentOut;
        parentAnim.Play();
        parentAnim.clip = parentIn;
    }

}
