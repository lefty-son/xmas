using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultipleBoxShaker : MonoBehaviour {

    public bool chosen;
    public Button keepGoin;
    public static MultipleBoxShaker instance;
    public Animation parentAnim;
    public AnimationClip parentIn, parentOut;
    private Image boxImg;
    private Button boxBtn;
    public GameObject fader;
    public GameObject hurray;

    private void Awake()
    {
        if (instance == null) instance = this;
        chosen = false;
        boxImg = GetComponent<Image>();
        boxBtn = GetComponent<Button>();
        boxBtn.onClick.AddListener(Shake);
        keepGoin.onClick.AddListener(KeepGoing);
        keepGoin.gameObject.SetActive(false);
    }

    public void Shake()
    {
        StartCoroutine(Shaking());
        chosen = true;
        MultipleBoxHider.instance.AnimateHide();
    }

    private void OnEnable()
    {
        keepGoin.gameObject.SetActive(false);
        parentAnim.transform.localScale = Vector3.one;
        boxImg.transform.localScale = Vector3.one;
        parentAnim.GetComponent<RectTransform>().offsetMin = new Vector2(800, 0);
        parentAnim.GetComponent<RectTransform>().offsetMax = new Vector2(800, 0);
    }
    private void OnDisable()
    {
        hurray.SetActive(false);
    }

    public void KeepGoing()
    {
        parentAnim.clip = parentOut;
        parentAnim.Play();
        parentAnim.clip = parentIn;
    }

    IEnumerator Shaking()
    {
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
        chosen = false;
        boxImg.transform.localScale = Vector3.zero;
        keepGoin.gameObject.SetActive(true);
        fader.SetActive(true);
        MultipleBoxHider.instance.ShowRandomReward();
        hurray.SetActive(true);
    }

}
