using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KilledUIManager : MonoBehaviour
{
    public Text killed;

    public static KilledUIManager killedInstance = null;

    private void Awake()
    {
        if (killedInstance == null)
        {
            killedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TextNull", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TextNull()
    {
        if (killed != null)
        {
            killed.text = " ";
        }
    }

public void KilledMonster()
    {
        killed.text = "killed";
    }
}
