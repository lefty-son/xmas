using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shaker : MonoBehaviour {
    public static Shaker instance;


    public Animation parentCloseAnim;
    public AnimationClip parentOpenClip;
    public AnimationClip parentCloseClip;

    public Button keepGoin;

    public GameObject newOne;

    public Animation nameAnim;
    public Text nameHolder;

    public Sprite realImage;
    public GameObject fader;
    private Image img;

    public GameObject hurray;

    private void Awake()
    {
        if (instance == null) instance = this;
        img = GetComponent<Image>();

        keepGoin.onClick.AddListener(KeepGoing);
    }

    private void OnEnable()
    {
        parentCloseAnim.transform.localScale = Vector3.one;
        parentCloseAnim.GetComponent<RectTransform>().offsetMin = new Vector2(800, 0);
        parentCloseAnim.GetComponent<RectTransform>().offsetMax = new Vector2(800, 0);
        StartCoroutine(Shaking());
    }

    public void Shake(){
        StartCoroutine(Shaking());
    }

    private void OnDisable()
    {
        hurray.SetActive(false);
    }

    IEnumerator Shaking(){
        img.color = Color.black;
        img.transform.localScale = Vector3.zero;
        keepGoin.gameObject.SetActive(false);
        nameAnim.transform.localScale = Vector3.zero;
        newOne.SetActive(false);

        while(realImage==null){
            yield return null;
        }

        img.sprite = realImage;
        var t = 0f;

        while (t <= 2f)
        {
            Vector3 rand = new Vector3(Random.Range(.75f, 1.25f), Random.Range(.75f, 1.25f), Random.Range(.75f, 1.25f));
            transform.localScale = Vector3.Lerp(Vector3.one, rand, t / 2f);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        keepGoin.gameObject.SetActive(true);

        nameAnim.Play();
        newOne.SetActive(true);
        hurray.SetActive(true);
        fader.SetActive(true);
        transform.localScale = Vector3.one;
        img.color = Color.white;

        realImage = null;

        // Spend Heart;
        GameManager.instance.SpendHeart(GiftManager.instance.giftCosts[PrefManager.instance.GetGiftTier()]);
        PrefManager.instance.SetGiftTier();

        GiftManager.instance.CheckGiftTier();
    }

    public void KeepGoing(){
        parentCloseAnim.clip = parentCloseClip;
        parentCloseAnim.Play();
        parentCloseAnim.clip = parentOpenClip;
        //transform.parent.gameObject.SetActive(false);
    }
}
