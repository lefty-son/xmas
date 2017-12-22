using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DollarReceiver : MonoBehaviour {

    public static DollarReceiver instance;

    private Text t;
    private Animation anim;
    private void Awake()
    {
        if (instance == null) instance = this;
        anim = GetComponent<Animation>();
        t = GetComponent<Text>();
    }

    public void ShowUI()
    {
        anim.Play();
        GameManager.instance.adViewd = false;
    }

    public void Offpanel(){
        transform.localScale = Vector3.zero;
    }
}
