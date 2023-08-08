using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveDistance;

    [SerializeField] private float roolSpeed;

    [SerializeField] private bool isMove;

    // Update is called once per frame
    void Update()
    {
        if (isMove)
            return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Move(Vector3.back);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Move(Vector3.left);
        }
    }

    private void Move(Vector3 dir)
    {
        Vector3 anchor = transform.position + (Vector3.down + dir) * moveDistance;
        Debug.Log(anchor);

        Vector3 axis = Vector3.Cross(Vector3.up, dir);
        StartCoroutine(Roll(anchor,axis));
    }

    private IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        isMove = true;
        for (int i = 0; i < (90/roolSpeed); i++)
        {
            transform.RotateAround(anchor,axis,roolSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        isMove = false;
    }
}
