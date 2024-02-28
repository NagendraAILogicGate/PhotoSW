namespace FrameworkHelper
{
    using System;
    using System.Runtime.CompilerServices;

    public class CropContraint
    {
        public CropContraint(string name, double? aspectRatio)
        {
            this.Name = name;
            this.AspectRatio = aspectRatio;
        }

        public double? AspectRatio { get; private set; }

        public string Name { get; private set; }
    }
}

