﻿using Microsoft.Xna.Framework;

namespace DwarfCorp
{
    /// <summary>
    /// An instance data represents a single instantiation of an object model
    /// at a given location, with a given color.
    /// </summary>
    public class NewInstanceData
    {
        [Newtonsoft.Json.JsonIgnore]
        public ulong RenderPass = 0;

        public string Type;

        public Vector3 Position;
        public Vector3 HalfSize;

        public bool Visible = true;

        private Matrix _transform;
        private NewInstanceManager Manager;

        [Newtonsoft.Json.JsonIgnore]
        public Matrix Transform
        {
            get
            {
                return _transform;
            }
            set
            {
                Manager.RemoveInstance(this);
                Position = value.Translation;
                _transform = value;
                Manager.AddInstance(this);
            }
        }

        public Color Color;
        public bool ShouldDraw;
        public Color SelectionBufferColor;

        public NewInstanceData(
            NewInstanceManager Manager,
            string Type,
            Vector3 HalfSize,
            Matrix Transform,
            Color Color,
            bool ShouldDraw)
        {
            this.Manager = Manager;
            this.Type = Type;
            this.HalfSize = HalfSize;
            this.Transform = Transform;
            this.Color = Color;
            this.ShouldDraw = ShouldDraw;
            SelectionBufferColor = Color.Black;
        }
    }

}