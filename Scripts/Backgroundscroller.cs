using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundscroller : MonoBehaviour
{
    [SerializeField] float backgroundscroller = 0.2f;
    Vector2 offset;
    Material MyMaterial;
    // Start is called before the first frame update
    void Start()
    {
        MyMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0f, backgroundscroller);

    }

    // Update is called once per frame
    void Update()
    {
        MyMaterial.mainTextureOffset += offset*Time.deltaTime;
    }
}
