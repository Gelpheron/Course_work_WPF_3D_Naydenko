using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Collections.Generic;
using System.Text;

namespace Курсова_робота_Найденко_Влад__10_А
{
    class Cone : Shapes
    {
        public Cone(double radiusBotom, double radiusTop, double height, int count, Point3D center, Color col, ref Model3DGroup All) : base(center)
        {
            CreateCone(center, radiusTop, radiusBotom, height, count, col, ref All);
        }
        //Переведення циліндричних координат у декартові.
        private Point3D GetPosition(double radius, double theta, double y)
        {
            Point3D pt = new Point3D();
            double sn = Math.Sin(theta * Math.PI / 180);
            double cn = Math.Cos(theta * Math.PI / 180);
            pt.X = radius * cn;
            pt.Y = y;
            pt.Z = -radius * sn;
            return pt;
        }
        //Створює зрізаний конус з заданим кольором(color), центром(center), радіусами вершини та основи (rtop,rbottom), висотою(height), а також із вказаною кількістю полігонів горизонталі(n).
        private void CreateCone(Point3D center, double rtop, double rbottom, double height, int n, Color color, ref Model3DGroup All)
        {
            if (n < 2)
                return;
            double h = height / 2;
            Point3D[] p = new Point3D[6];
            int coun = 0;
            MeshGeometry3D mesh = new MeshGeometry3D();
            for (int i = 0; i < n; i++)
            {
                p[0] = GetPosition(rtop, i * 360 / n, h);
                p[0] += (Vector3D)center;
                p[1] = GetPosition(rbottom, i * 360 / n, -h);
                p[1] += (Vector3D)center;
                p[2] = GetPosition(0, i * 360 / n, -h);
                p[2] += (Vector3D)center;
                p[3] = GetPosition(0, i * 360 / n, h);
                p[3] += (Vector3D)center;
                p[4] = GetPosition(rtop, (i+1) * 360 / n, h);
                p[4] += (Vector3D)center;
                p[5] = GetPosition(rbottom, (i+1) * 360 / n, -h);
                p[5] += (Vector3D)center;
                CreateTriangleFace(p[0], p[4], p[3],mesh, ref coun);
                CreateTriangleFace(p[2], p[5], p[1],mesh, ref coun);
                CreateTriangleFace(p[0], p[1], p[5],mesh, ref coun);
                CreateTriangleFace(p[0], p[5], p[4],mesh, ref coun);
            }
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = color;
            Material material = new DiffuseMaterial(brush);
            GeometryModel3D geometry = new GeometryModel3D(mesh, material);
            model = geometry;
            model.Transform = transform;
            All.Children.Add(model);
        }
    }
}
