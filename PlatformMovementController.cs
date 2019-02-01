using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementController : MonoBehaviour {

    public string tag;
    public bool auto;
    private GameObject platform;
    private float posY, posX;
    [SerializeField] private string Go;
    [SerializeField] private float distance;
    private void Start()
    {
        platform = transform.parent.gameObject;
        auto = false;
        posY = Mathf.Round(platform.transform.position.y);
        posX = Mathf.Round(platform.transform.position.x);
        if (distance == 0) { distance = 3; }


    }
  
    private void OnTriggerExit(Collider col)
    {
        print("Exit");
        auto = true;
        col.transform.parent = null;

    }
  
    private void OnTriggerStay(Collider col)
    {
    
        auto = false;
        col.transform.parent = platform.transform;
        Run();
    }
    private void Update()
    {
        moveTo();
        if (auto) {  Run();  }

    }
  
    void Run()
    {
  
            switch (Go) {
            case "UP":platform.transform.Translate(Vector3.up * Time.deltaTime*2); break;
            case "DOWN":platform.transform.Translate(Vector3.down * Time.deltaTime*2); break;
            case "LEFT":platform.transform.Translate(Vector3.left * Time.deltaTime*3); break;
            case "RIGHT":platform.transform.Translate(Vector3.right * Time.deltaTime*3); break; }

    }

    void moveTo()
    {
        switch (tag)
        {
            case "UpDown":
                if (Mathf.Round(platform.transform.position.y) == posY) { Go = "UP"; }
                else if (Mathf.Round(platform.transform.position.y) == (posY + distance)) { Go = "DOWN"; }
                break;
            case "LeftRight":
                if (Mathf.Round(platform.transform.position.x) == posX) { Go = "LEFT"; }
                else if (Mathf.Round(platform.transform.position.x) == (posX + distance)) { Go = "RIGHT"; }
                break;
            case "RightLeft":
                if (Mathf.Round(platform.transform.position.x) == posX) { Go = "RIGHT"; }
                else if (Mathf.Round(platform.transform.position.x) == (posX + distance)) { Go = "LEFT"; }
                break;
        }

    }
}



