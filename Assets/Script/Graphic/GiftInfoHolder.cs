using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GiftInfoHolder : MonoBehaviour {

    public static GiftInfoHolder instance;

    public TextMesh infoPrice;

    Vector3 uiPosition;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

	void Start () {
        uiPosition = Camera.main.WorldToScreenPoint(this.transform.position); 
	}

    public void ShowInfo(){
        
        var price = Tap.instance.reward[GiftSpawner.instance.uniqIndex].dollar;
        StringBuilder stb = new StringBuilder();
        stb.Append(price);
        stb.Append("$");
        infoPrice.text = stb.ToString();
        infoPrice.gameObject.SetActive(true);
    }

    public void HideInfo(){
        infoPrice.text = "";
        infoPrice.gameObject.SetActive(false);
    }
	
}
