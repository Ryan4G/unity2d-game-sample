using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    bool m_isHit = false;

    Vector3 m_startPos;

    SpriteRenderer m_spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        m_spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    bool IsHit()
    {
        m_isHit = false;

        Vector3 ms = Input.mousePosition;

        ms = Camera.main.ScreenToWorldPoint(ms);

        Vector3 pos = this.transform.position;

        float w = m_spriteRenderer.bounds.extents.x;
        float h = m_spriteRenderer.bounds.extents.y;

        if (ms.x > pos.x - w && ms.x < pos.x + w &&
            ms.y > pos.y - h && ms.y < pos.y + h)
        {
            m_isHit = true;
        }

        return m_isHit;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsHit())
        {
            m_startPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0) && m_isHit)
        {
            Vector3 endPos = Input.mousePosition;

            Vector3 v = (m_startPos - endPos) * 3.0f;

            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            this.GetComponent<Rigidbody2D>().AddForce(v);
        }
    }
}
