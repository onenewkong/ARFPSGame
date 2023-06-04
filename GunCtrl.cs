using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GunCtrl : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePosition;
    public GameObject bullet;

    public new AudioSource audio;

    public Queue<GameObject> bulletObjectPool = new Queue<GameObject>();

    int poolSize = 5;

    // Start is called before the first frame update
    void Start()
    {
        bullet = Instantiate(bulletFactory);
        bullet.SetActive(false);

        for (int i = 0; i < poolSize; ++i)
        {
            bulletObjectPool.Enqueue(bullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (bulletObjectPool.Count > 0)
            {
                GameObject UsingBullet = bulletObjectPool.Dequeue();

                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    UsingBullet.SetActive(true);
                    UsingBullet.transform.position = firePosition.transform.position;
                    
                    UsingBullet.GetComponent<Rigidbody>().AddForce(transform.forward*(35f), ForceMode.Impulse);

                    gameObject.GetComponent<AudioSource>().Play();
                }
            }
            bullet = Instantiate(bulletFactory);
            bullet.SetActive(false);
            bulletObjectPool.Enqueue(bullet);
        }
    }
}