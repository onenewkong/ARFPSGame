using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCtrl : MonoBehaviour
{
    public GameObject blood;
    public static BloodCtrl bloodInstance = null;

    private void Awake()
    {
        blood.SetActive(false);

        if (bloodInstance == null)
        {
            bloodInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
