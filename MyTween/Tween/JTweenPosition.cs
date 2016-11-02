//*********************************************************************
//
//					   ScriptName 	: MoveFormTo
//                                 
//                                 
//*********************************************************************

using UnityEngine;
using System.Collections;
using DG.Tweening;
namespace Game.DoTween.Expand
{
    public class JTweenPosition : JDOTweenBase
    {
        public Vector3 Form;
        public Vector3 To;
        public float duration = 1f;
        public float delay = 0f;
        Transform my;
        Transform myTransform
        {
            get
            {
                if (my == null)
                    my = transform;
                return my;
            }
        }
        Vector3 position
        {
            get
            {
                return myTransform.position;
            }
        }
        public override void PlayForward()
        {
            StyleFunction(this.Form, this.To);
        }
        public override void PlayReverse()
        {
            StyleFunction(this.To, this.Form);
        }
        void StyleFunction(Vector3 From, Vector3 To)
        {
            switch (style)
            {
                case Style.Once:
                    One(From, To);
                    break;
                case Style.Loop:
                    Loop(From, To);
                    break;
                case Style.Repeatedly:
                    Repeatedly(From, To);
                    break;
                case Style.PingPong:
                    PingPong(From, To);
                    break;
            }
        }
        void One(Vector3 From, Vector3 To)
        {
            myTransform.position = From;
            myTransform.DOMove(To, duration).OnComplete(() => OnComplete());
        }
        void Repeatedly(Vector3 From, Vector3 To)
        {
            myTransform.position = From;
            myTransform.DOMove(To, duration).OnComplete(() => myTransform.DOMove(Form, duration));
        }
        void Loop(Vector3 From, Vector3 To)
        {
            myTransform.position = From;
            myTransform.DOMove(To, duration).OnComplete(() => Loop(Form, To));
        }
        void PingPong(Vector3 From, Vector3 To)
        {
            myTransform.DOMove(To, duration).OnComplete(() => PingPong(To, From));
        }
        protected override void StartValue()
        {
            Form = this.position;
        }
        protected override void EndValue()
        {
            To = this.position;
        }
    }
}
