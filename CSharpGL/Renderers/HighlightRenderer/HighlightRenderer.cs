﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 高亮显示指定的图元。
    /// </summary>
    public partial class HighlightRenderer : Renderer
    {
        /// <summary>
        /// 
        /// </summary>
        protected string positionNameInIBufferable;
        internal PropertyBufferPtr positionBufferPtr;

        /// <summary>
        /// 高亮显示指定的图元。
        /// </summary>
        /// <param name="bufferable">一种渲染方式</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        public HighlightRenderer(IBufferable bufferable,
            string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(bufferable, HighlightShaderHelper.GetHighlightShaderCode(),
                new PropertyNameMap("in_Position", positionNameInIBufferable),
                switches)
        {
            this.Name = this.GetType().Name;

            this.positionNameInIBufferable = positionNameInIBufferable;
            this.UniformVariables.Add(new UniformVec4("highlightColor", new vec4(1, 1, 1, 1)));
            this.UniformVariables.Add(this.uniformMVP);
            this.SwitchList.Add(new PolygonModeSwitch(PolygonModes.Lines));
            this.SwitchList.Add(new LineWidthSwitch(10.0f));
            this.SwitchList.Add(new PointSizeSwitch(20.0f));
            this.SwitchList.Add(new PolygonOffsetFillSwitch());
            this.SwitchList.Add(new PolygonOffsetPointSwitch());

        }

    }


}
