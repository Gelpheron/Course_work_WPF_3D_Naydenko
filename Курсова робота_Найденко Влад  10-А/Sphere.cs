using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Курсова_робота_Найденко_Влад__10_А
{
    class Sphere : Shapes
    {
        public Sphere(Point3D centre, double r,int u,int v, Color col, ref Model3DGroup All):base(centre)
        {
            CreateSphere(centre, r, u, v, col, ref All);
        }
        //Створює сферу з заданим кольором(color), центром(center) та радіусом(radius), а також із вказаною кількістю полігонів по вертикалі та горизонталі(u,v)
        private void CreateSphere(Point3D center, double radius, int u, int v, Color color, ref Model3DGroup All)
        {
            int coun = 0;
            if (u < 2 || v < 2) return;
            Point3D[] p = new Point3D[4];
            MeshGeometry3D mesh = new MeshGeometry3D();
            for (int i = 0; i < u ; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    p[0] = GetPositionSP(radius, i * 180 / u, j * 360 / v);
                    p[0] += (Vector3D)center;
                    p[1] = GetPositionSP(radius, (i +1)* 180 / u, j * 360 / v);
                    p[1] += (Vector3D)center;
                    p[2] = GetPositionSP(radius, (i + 1) * 180 / u, (j+1) * 360 / v);
                    p[2] += (Vector3D)center;
                    p[3] = GetPositionSP(radius, i * 180 / u, (j+1) * 360 / v);
                    p[3] += (Vector3D)center;
                    CreateTriangleFace(p[0], p[1], p[2],  mesh, ref coun);
                    CreateTriangleFace(p[2], p[3], p[0],  mesh, ref coun);
                }
            }
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = color;
            Material material = new DiffuseMaterial(brush);
            GeometryModel3D geometry = new GeometryModel3D(mesh, material);
            model = geometry;
            model.Transform = transform;
            All.Children.Add(model);
        }
        //Переведення сферичних координат у декартові.
        private Point3D GetPositionSP(double radius, double theta, double phi)
        {
            double snt = Math.Sin(theta * Math.PI / 180);
            double cnt = Math.Cos(theta * Math.PI / 180);
            double snp = Math.Sin(phi * Math.PI / 180);
            double cnp = Math.Cos(phi * Math.PI / 180);
            return new Point3D(radius * snt * cnp, radius * cnt, -radius * snt * snp);
        }
    }

}

