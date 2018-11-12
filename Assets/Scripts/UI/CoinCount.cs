using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour {

    public Text count;
        public int coinPickup = 20;
    public int currentCount;

    public static CoinCount Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }



    public void Start()
    {
        currentCount = 0;
        Score();
    }

   public void PickUP()
    {
        currentCount = currentCount + coinPickup;
        Score();
    }

    void Score()
    {
        count.text = "Score:" + currentCount.ToString();
    }
}
