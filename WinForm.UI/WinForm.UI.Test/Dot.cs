using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WinForm.UI.Test
{
    /****************************************************************
	*   作者：yuanj
	*   CLR版本：4.0.30319.42000
	*   创建时间：2018/01/18 19:50:15
	*   2018
	*   描述说明：表示一个"点" 
	*
	*   修改历史：
	*
	*
	*****************************************************************/
    internal sealed class Dot
    {
        #region 字段/属性  

        //圆心  
        private readonly PointF _circleCenter;
        //半径  
        private readonly float _circleRadius;

        /// <summary>  
        /// 当前帧绘图坐标，在每次DoAction()时重新计算  
        /// </summary>  
        public PointF Location;

        //点相对于圆心的角度，用于计算点的绘图坐标  
        private int _angle;
        //透明度  
        private int _opacity;
        //动画进度  
        private int _progress;
        //速度  
        private int _speed;

        /// <summary>  
        /// 透明度  
        /// </summary>  
        public int Opacity
        {
            get { return _opacity < MinOpacity ? MinOpacity : (_opacity > MaxOpacity ? MaxOpacity : _opacity); }
        }

        #endregion

        #region 常量  

        //最小/最大速度  
        private const int MinSpeed = 2;
        private const int MaxSpeed = 11;

        //出现区的相对角度          
        private const int AppearAngle = 90;
        //减速区的相对角度  
        private const int SlowAngle = 225;
        //加速区的相对角度  
        private const int QuickAngle = 315;

        //最小/最大角度  
        private const int MinAngle = 0;
        private const int MaxAngle = 360;

        //淡出速度  
        private const int AlphaSub = 25;

        //最小/最大透明度  
        private const int MinOpacity = 0;
        private const int MaxOpacity = 255;

        #endregion 常量  

        #region 构造器  

        public Dot(PointF circleCenter, float circleRadius)
        {
            Reset();
            _circleCenter = circleCenter;
            _circleRadius = circleRadius;
        }

        #endregion 构造器  

        #region 方法  

        /// <summary>  
        /// 重新计算当前帧绘图坐标  
        /// </summary>  
        private void ReCalcLocation()
        {
            Location = Common.GetDotLocationByAngle(_circleCenter, _circleRadius, _angle);
        }

        /// <summary>  
        /// 点动作  
        /// </summary>  
        public void DotAction()
        {
            switch (_progress)
            {
                case 0:
                    {
                        _opacity = MaxOpacity;
                        AddSpeed();
                        if (_angle + _speed >= SlowAngle && _angle + _speed < QuickAngle)
                        {
                            _progress = 1;
                            _angle = SlowAngle - _speed;
                        }
                    }
                    break;
                case 1:
                    {
                        SubSpeed();
                        if (_angle + _speed >= QuickAngle || _angle + _speed < SlowAngle)
                        {
                            _progress = 2;
                            _angle = QuickAngle - _speed;
                        }
                    }
                    break;
                case 2:
                    {
                        AddSpeed();
                        if (_angle + _speed >= SlowAngle && _angle + _speed < QuickAngle)
                        {
                            _progress = 3;
                            _angle = SlowAngle - _speed;
                        }
                    }
                    break;
                case 3:
                    {
                        SubSpeed();
                        if (_angle + _speed >= QuickAngle && _angle + _speed < MaxAngle)
                        {
                            _progress = 4;
                            _angle = QuickAngle - _speed;
                        }
                    }
                    break;
                case 4:
                    {
                        SubSpeed();
                        if (_angle + _speed >= MinAngle && _angle + _speed < AppearAngle)
                        {
                            _progress = 5;
                            _angle = MinAngle;
                        }
                    }
                    break;
                case 5:
                    {
                        AddSpeed();
                        FadeOut();
                    }
                    break;
            }

            //移动  
            _angle = _angle >= (MaxAngle - _speed) ? MinAngle : _angle + _speed;
            //重新计算坐标  
            ReCalcLocation();
        }

        //淡出  
        private void FadeOut()
        {
            if ((_opacity -= AlphaSub) <= 0)
                _angle = AppearAngle;
        }

        //重置状态  
        public void Reset()
        {
            _angle = AppearAngle;
            _speed = MinSpeed;
            _progress = 0;
            _opacity = 1;
        }

        //加速  
        private void AddSpeed()
        {
            if (++_speed >= MaxSpeed) _speed = MaxSpeed;
        }

        //减速  
        private void SubSpeed()
        {
            if (--_speed <= MinSpeed) _speed = MinSpeed;
        }

        #endregion 方法  
    }
}
