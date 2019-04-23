using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WinForm.UI.Controls
{
    /// <summary>
    /// 表示一个"点"  
    /// </summary>
    internal sealed class LoadingDot
    {
        #region 字段/属性  

        [Description("圆心")] private readonly PointF _circleCenter;
        [Description("半径")] private readonly float _circleRadius;

        /// <summary>  
        /// 当前帧绘图坐标，在每次DoAction()时重新计算  
        /// </summary>  
        public PointF Location;

        [Description("点相对于圆心的角度，用于计算点的绘图坐标")] private int _angle;
        [Description("透明度")] private int _opacity;
        [Description("动画进度")] private int _progress;
        [Description("速度")] private int _speed;

        [Description("透明度")]
        public int Opacity => _opacity < MinOpacity ? MinOpacity : (_opacity > MaxOpacity ? MaxOpacity : _opacity);

        #endregion

        #region 常量  

        [Description("最小速度")] private const int MinSpeed = 2;
        [Description("最大速度")] private const int MaxSpeed = 11;

        [Description("出现区的相对角度")] private const int AppearAngle = 90;
        [Description("减速区的相对角度")] private const int SlowAngle = 225;
        [Description("加速区的相对角度")] private const int QuickAngle = 315;

        [Description("最小角度")] private const int MinAngle = 0;
        [Description("最大角度")] private const int MaxAngle = 360;

        [Description("淡出速度")] private const int AlphaSub = 25;

        [Description("最小透明度")] private const int MinOpacity = 0;
        [Description("最大透明度")] private const int MaxOpacity = 255;

        #endregion 常量  

        #region 构造器  

        public LoadingDot(PointF circleCenter, float circleRadius)
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
            Location = GetDotLocationByAngle(_circleCenter, _circleRadius, _angle);
        }

        /// <summary>  
        /// 点动作
        /// </summary>  
        public void LoadingDotAction()
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

        /// <summary>
        /// 淡出
        /// </summary>
        private void FadeOut()
        {
            if ((_opacity -= AlphaSub) <= 0)
                _angle = AppearAngle;
        }


        /// <summary>
        /// 重置状态
        /// </summary>
        public void Reset()
        {
            _angle = AppearAngle;
            _speed = MinSpeed;
            _progress = 0;
            _opacity = 1;
        }

        /// <summary>
        /// 加速
        /// </summary>
        private void AddSpeed()
        {
            if (++_speed >= MaxSpeed) _speed = MaxSpeed;
        }

        /// <summary>
        /// 减速
        /// </summary>
        private void SubSpeed()
        {
            if (--_speed <= MinSpeed) _speed = MinSpeed;
        }

        #endregion 方法  

        /// <summary>  
        /// 根据半径、角度求圆上坐标
        /// </summary>  
        /// <param name="center">圆心</param>  
        /// <param name="radius">半径</param>  
        /// <param name="angle">角度</param>  
        /// <returns>坐标</returns>  
        public static PointF GetDotLocationByAngle(PointF center, float radius, int angle)
        {
            var x = (float)(center.X + radius * Math.Cos(angle * Math.PI / 180));
            var y = (float)(center.Y + radius * Math.Sin(angle * Math.PI / 180));

            return new PointF(x, y);
        }
    }
}
