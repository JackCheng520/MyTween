//*********************************************************************
//
//					   ScriptName 	: TweenScale
//                                 
//                                 
//*********************************************************************

using UnityEngine;
using System.Collections;
using DG.Tweening;
namespace Game.DoTween.Expand
{
    public class JTweenScale : JDOTweenBase
    {

        public Vector3 formScale;
        public Vector3 toScale;
        public float duration = 1f;
        public float delay = 0f;
        Transform tr;
        Transform myTransform
        {
            get
            {
                if (tr == null)
                    tr = transform;
                return tr;
            }
            set
            {
                tr = value;
            }
        }

        Vector3 Scale
        {
            get
            {
                return myTransform.localScale;
            }
        }

        public override void PlayForward()
        {
            StyleFunction(formScale, toScale);
        }
        public override void PlayReverse()
        {
            StyleFunction(toScale, formScale);
        }

        void StyleFunction(Vector3 from, Vector3 to)
        {
            switch (style)
            {
                case Style.Once:
                    One(from, to);
                    break;
                case Style.Loop:
                    Loop(from, to);
                    break;
                case Style.Repeatedly:
                    Repeatedly(from, to);
                    break;
                case Style.PingPong:
                    PingPong(from, to);
                    break;
            }
        }
        void One(Vector3 from, Vector3 to)
        {
            myTransform.localScale = from;
            myTransform.DOScale(to, duration).OnComplete(() => OnComplete()).SetDelay(delay);
        }
        void Repeatedly(Vector3 from, Vector3 to)
        {
            myTransform.localScale = from;
            myTransform.DOScale(to, duration).OnComplete(() => myTransform.DOScale(from, duration)).SetDelay(delay);
        }
        void Loop(Vector3 from, Vector3 to)
        {
            myTransform.localScale = from;
            myTransform.DOScale(to, duration).OnComplete(() => Loop(from, to)).SetDelay(delay);
        }
        void PingPong(Vector3 from, Vector3 to)
        {
            myTransform.DOScale(to, duration).OnComplete(() => PingPong(to, from)).SetDelay(delay);
        }

        protected override void StartValue()
        {
            formScale = Scale;
        }
        protected override void EndValue()
        {
            toScale = Scale;
        }
    }
}
