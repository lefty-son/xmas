using System.Text;
using UnityEngine;
using UnityEngine.UI;
public class HeartReceiver : MonoBehaviour {

    public static HeartReceiver instance;
    private Text t;
    private Animation anim;
    private void Awake()
    {
        if (instance == null) instance = this;
        anim = GetComponent<Animation>();
        t = GetComponent<Text>();
    }

    public void ShowUI(){
 
        anim.Play();
    }
}
