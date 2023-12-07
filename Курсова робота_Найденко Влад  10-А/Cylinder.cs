using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Collections.Generic;
using System.Text;

namespace Курсова_робота_Найденко_Влад__10_А
{
    class Cylinder : Shapes
    {
        public Cylinder(Point3D centerFirst,double radiusIn, double height, double radius, int n, Color color, ref Model3DGroup All) : base(centerFirst)
        {
            CreateCylinder(centerFirst, radiusIn, radius, height, n, color, ref All);
        }
        //Переведення циліндричних координат у декартові.
        private Point3D GetPositionCY(double radius, double theta, double y)
        {
            Point3D pt = new Point3D();
            double sn = Math.Sin(theta * Math.PI / 180);
            double cn = Math.Cos(theta * Math.PI / 180);
            pt.X = radius * cn;
            pt.Y = y;
            pt.Z = -radius * sn;
            return pt;
        }
        //Створює циліндр з заданим кольором(color), центром(center), радіусами циліндру та порожнини(rout,rin), висотою(height), а також із вказаною кількістю полігонів горизонталі(n).
        private void CreateCylinder(Point3D center, double rin, double rout, double height, int n, Color color, ref Model3DGroup All)
        {
            if (n < 2 || rin == rout) return;
            double radius = rin;
            if (rin > rout)
            {
                rin = rout;
                rout = radius;
            }
            double h = height / 2;
            Point3D[] p = new Point3D[8];
            int coun = 0;
            MeshGeometry3D mesh = new MeshGeometry3D();
            for (int i = 0; i < n; i++)
            {
                p[0] = GetPositionCY(rout, i * 360 / n, h);
                p[0] += (Vector3D)center;
                p[1] = GetPositionCY(rout, i * 360 / n, -h);
                p[1] += (Vector3D)center;
                p[2] = GetPositionCY(rin, i * 360 / n, -h);
                p[2] += (Vector3D)center;
                p[3] = GetPositionCY(rin, i * 360 / n, h);
                p[3] += (Vector3D)center;
                p[4] = GetPositionCY(rout, (i+1) * 360 / n, h);
                p[4] += (Vector3D)center;
                p[5] = GetPositionCY(rout, (i+1) * 360 / n, -h);
                p[5] += (Vector3D)center;
                p[6] = GetPositionCY(rin, (i+1) * 360 / n, -h);
                p[6] += (Vector3D)center;
                p[7] = GetPositionCY(rin, (i+1) * 360 / n, h);
                p[7] += (Vector3D)center;
                CreateTriangleFace(p[0], p[4], p[3], mesh, ref coun);
                CreateTriangleFace(p[4], p[7], p[3], mesh, ref coun);

                CreateTriangleFace(p[2], p[5], p[1], mesh, ref coun);
                CreateTriangleFace(p[2], p[6], p[5], mesh, ref coun);

                CreateTriangleFace(p[0], p[1], p[4], mesh, ref coun);
                CreateTriangleFace(p[1], p[5], p[4], mesh, ref coun);

                CreateTriangleFace(p[2], p[7], p[6], mesh, ref coun);
                CreateTriangleFace(p[2], p[3], p[7], mesh, ref coun);
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
