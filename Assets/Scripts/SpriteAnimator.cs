using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    protected SpriteRenderer m_sprite;

    public Sprite[] m_clips;

    protected float timer = 0.1f;

    protected int m_frame = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_sprite = this.gameObject.GetComponent<SpriteRenderer>();
        m_sprite.sprite = m_clips[m_frame];
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = 0.1f;

            m_frame++;

            if (m_frame >= m_clips.Length)
            {
                m_frame = 0;
            }

            m_sprite.sprite = m_clips[m_frame];
        }
    }
}
