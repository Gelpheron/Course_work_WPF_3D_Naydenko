using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Collections.Generic;
using System.Text;

namespace Курсова_робота_Найденко_Влад__10_А
{
    class Torus : Shapes
    {
        public Torus(Point3D Center, double R, double r, int N, int n, Color col, ref Model3DGroup All) : base(Center)
        {
            CreateTorus(Center, R, r, N,n,col, ref All);
        }
        //Параметричні рівняння тору
        private Point3D GetPosition(double R, double r, double t, double p)
        {
            Point3D pt = new Point3D();
            double snt = Math.Sin(t * Math.PI / 180);
            double cnt = Math.Cos(t * Math.PI / 180);
            double snp = Math.Sin(p * Math.PI / 180);
            double cnp = Math.Cos(p * Math.PI / 180);
            pt.X = (R + r * cnp) * cnt;
            pt.Y = r * snp;
            pt.Z = -(R + r * cnp) * snt;
            return pt;
        }
        //Створює тор з заданим кольором(color), центром(center), радіусом утворюючого кола та радіусом порожнини (r,R), а також із вказаною кількістю полігонів по вертикалі та горизонталі(n,N)
        private void CreateTorus(Point3D center, double R, double r, int N, int n, Color color, ref Model3DGroup All)
        {
            if (N < 2 || n < 2)
                return;
            Point3D[] p = new Point3D[4];
            int coun = 0;
            MeshGeometry3D mesh = new MeshGeometry3D();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    p[0] = GetPosition(R, r, i * 360 / N, j * 360 / n);
                    p[0] += (Vector3D)center;
                    p[1] = GetPosition(R, r, (i+1) * 360 / N, j * 360 / n);
                    p[1] += (Vector3D)center;
                    p[2] = GetPosition(R, r, (i+1) * 360 / N, (j+1) * 360 / n);
                    p[2] += (Vector3D)center;
                    p[3] = GetPosition(R, r, i * 360 / N, (j+1) * 360 / n);
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
            All.Children.Add(geometry);
        }
    }
}
