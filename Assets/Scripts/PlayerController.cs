using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(MapCreater.Instance.CheckMap((int)Mathf.Ceil((transform.position + transform.right).x), (int)Mathf.Ceil((transform.position + transform.right).z)))
            {
                transform.eulerAngles = new Vector3(0, 90, 0);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (MapCreater.Instance.CheckMap((int)Mathf.Ceil((transform.position - transform.right).x), (int)Mathf.Ceil((transform.position - transform.right).z)))
                transform.eulerAngles = new Vector3(0, -90, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (MapCreater.Instance.CheckMap((int)Mathf.Ceil(transform.position.x), (int)Mathf.Ceil((transform.position + transform.up).z)))
                transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (MapCreater.Instance.CheckMap((int)Mathf.Ceil(transform.position.x), (int)Mathf.Ceil((transform.position - transform.up).z)))
                transform.eulerAngles = new Vector3(0, 180, 0);
        }

        rb.velocity = transform.forward * speed * Time.deltaTime;
    }

    void OnGUI()
    {
        // プレイヤーの位置を左上に表示
        GUI.Box(new Rect(10, 10, 100, 23), ChengeVector(transform.position).ToString());
    }

    Vector3 ChengeVector(Vector3 pos)
    {
        Vector3 newPos = Vector3.zero;

        newPos.x = Mathf.Ceil(pos.x / 3);
        newPos.z = Mathf.Ceil(pos.z / 3 * -1);
        return newPos;
    }
}
