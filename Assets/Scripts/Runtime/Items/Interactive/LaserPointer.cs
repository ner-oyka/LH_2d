using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Items
{
    public class LaserPointer : BaseItem
    {
        private LineRenderer m_LineRenderer;
        private Transform m_Target;

        void Start()
        {
            m_LineRenderer = GetComponent<LineRenderer>();
            m_LineRenderer.useWorldSpace = true;
            //test
            m_Target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        void Update()
        {
            RaycastHit2D hit = Physics2D.Linecast(transform.position, m_Target.position);
            if (hit)
            {
                m_LineRenderer.SetPosition(0, transform.position);
                m_LineRenderer.SetPosition(1, hit.point);
            }
        }
    }
}
