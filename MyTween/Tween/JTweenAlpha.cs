//*********************************************************************
//
//					   ScriptName 	: TweenAlpha
//                                 
//                                 
//*********************************************************************

using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
namespace Game.DoTween.Expand
{
    public class JTweenAlpha : JDOTweenBase
    {
        public float StartAlpha;
        public float EndAlpha;
        public float durtion = 1f;
        public float delay = 0f;

        MaskableGraphic _graphic;
        MaskableGraphic graphic
        {
            get
            {
                if (_graphic == null)
                {
                    _graphic = gameObject.GetComponent<MaskableGraphic>();
                }
                return _graphic;
            }
            set
            {
                _graphic = value;
            }
        }
        public float GetAlpha
        {
            get
            {
                return graphic.color.a;
            }
        }

        bool Forward = true;
        public override void PlayForward()
        {
            Forward = true;
            StyleFunction(StartAlpha, EndAlpha, durtion, style);
        }
        public override void PlayReverse()
        {
            Forward = false;
            StyleFunction(EndAlpha, StartAlpha, durtion, style);
        }

        void StyleFunction(float fromAlpha, float toAlpha, float animTime, JDOTweenBase.Style style)
        {
            if (graphic == null)
            {
                Des();
                return;
            }
            //  SetChildAlpha(fromAlpha, toAlpha, animTime, style);
            switch (style)
            {
                case Style.Once:
                    One(fromAlpha, toAlpha, animTime);
                    break;
                case Style.Loop:
                    Loop(fromAlpha, toAlpha, animTime);
                    break;
                case Style.Repeatedly:
                    Repeatedly(fromAlpha, toAlpha, animTime);
                    break;
                case Style.PingPong:
                    PingPong(fromAlpha, toAlpha, animTime);
                    break;
            }
        }

        void One(float fromAlpha, float toAlpha, float time)
        {
            graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, fromAlpha);
            DOTween.ToAlpha(() => graphic.color, x => graphic.color = x, toAlpha, time).OnComplete(() => OnComplete()).SetDelay(delay);
        }
        void Repeatedly(float fromAlpha, float toAlpha, float time)
        {
            graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, fromAlpha);
            DOTween.ToAlpha(() => graphic.color, x => graphic.color = x, toAlpha, time).OnComplete(() => DOTween.ToAlpha(() => graphic.color, x => graphic.color = x, fromAlpha, time)).SetDelay(delay);
        }
        void Loop(float fromAlpha, float toAlpha, float time)
        {
            graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, fromAlpha);
            DOTween.ToAlpha(() => graphic.color, x => graphic.color = x, EndAlpha, time).OnComplete(() => Loop(fromAlpha, toAlpha, time)).SetDelay(delay);
        }
        void PingPong(float fromAlpha, float toAlpha, float time)
        {
            DOTween.ToAlpha(() => graphic.color, x => graphic.color = x, toAlpha, time).OnComplete(() => PingPong(toAlpha, fromAlpha, time)).SetDelay(delay);
        }

        protected override void StartValue()
        {
            if (graphic)
            {
                StartAlpha = graphic.color.a;
                EndAlpha = graphic.color.a;
                return;
            }
        }

        void Des()
        {
            Destroy(GetComponent<JTweenAlpha>(), 1f);
            //HCTweenTextAlpha text = gameObject.AddComponent<HCTweenTextAlpha>();
            //text.StartAlpha       = this.StartAlpha;
            //text.EndAlpha         = this.EndAlpha;
            //text.durtion          = this.durtion;
            //text.style            = this.style;
            //text.IsStartRun       = this.IsStartRun;
            //if (Forward)
            //    text.PlayForward();
            //else
            //    text.PlayReverse();

        }
    }
}
