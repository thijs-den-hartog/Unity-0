using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounchBlock : MonoBehaviour
{
    public float BounchForce = 10f;
    public GameObject JumpText;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        JumpText.SetActive(false);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("BounchBlock"))
        {
            
             rb.AddForce(0, BounchForce, 0, ForceMode.Impulse);
             JumpText.SetActive(true);
            
        }
        
        }
    }
//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
