using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Курсова_робота_Найденко_Влад__10_А
{
    public class Shapes
    {
        protected GeometryModel3D model;
        protected Transform3DGroup transform = new Transform3DGroup();
        protected ScaleTransform3D ScaleValue = new ScaleTransform3D(1, 1, 1);
        protected AxisAngleRotation3D AxX = new AxisAngleRotation3D(new Vector3D(1, 0, 0), 0);
        protected AxisAngleRotation3D AxY = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);
        protected AxisAngleRotation3D AxZ = new AxisAngleRotation3D(new Vector3D(0, 0, 1), 0);
        protected TranslateTransform3D offset = new TranslateTransform3D(0,0,0);

        public Shapes(Point3D centre)
        {
            ScaleValue.CenterX = centre.X;
            ScaleValue.CenterY = centre.Y;
            ScaleValue.CenterZ = centre.Z;
            //
            transform.Children.Add(ScaleValue);

            RotateTransform3D RotateTransformX = new RotateTransform3D(AxX);
            RotateTransform3D RotateTransformY = new RotateTransform3D(AxY);
            RotateTransform3D RotateTransformZ = new RotateTransform3D(AxZ);
            //
            RotateTransformX.CenterX = centre.X;
            RotateTransformX.CenterY = centre.Y;
            RotateTransformX.CenterZ = centre.Z;

            RotateTransformY.CenterX = centre.X;
            RotateTransformY.CenterY = centre.Y;
            RotateTransformY.CenterZ = centre.Z;

            RotateTransformZ.CenterX = centre.X;
            RotateTransformZ.CenterY = centre.Y;
            RotateTransformZ.CenterZ = centre.Z;
            //
            transform.Children.Add(RotateTransformX);
            transform.Children.Add(RotateTransformY);
            transform.Children.Add(RotateTransformZ);
            transform.Children.Add(offset);
        }
        //повертає об'єкт навколо осі X на задану кількість градусів
        public void RotateX(double AngleX)
        {
           AxX.Angle = AngleX;
        }
        //повертає об'єкт навколо осі Y на задану кількість градусів
        public void RotateY(double AngleY)
        {
            AxY.Angle = AngleY;
        }
        //повертає об'єкт навколо осі Z на задану кількість градусів
        public void RotateZ(double AngleZ)
        {
            AxZ.Angle = AngleZ;
        }
        //масштабує об'єкт у 2 рази по осі X у задану кількість разів
        public void ScaleX(double ScaleX)
        {
            ScaleValue.ScaleX = ScaleX;
        }
        //масштабує об'єкт у 2 рази по осі Y у задану кількість разів
        public void ScaleY(double ScaleY)
        {
            ScaleValue.ScaleY = ScaleY;
        }
        //масштабує об'єкт у 2 рази по осі Z у задану кількість разів
        public void ScaleZ(double ScaleZ)
        {
            ScaleValue.ScaleZ = ScaleZ;
        }
        //зміщує об'єкт на зазначену відстань по осі X
        public void OffsetX(double OffsetX)
        {
            offset.OffsetX = OffsetX;
        }
        //зміщує об'єкт на зазначену відстань по осі Y
        public void OffsetY(double OffsetY)
        {
            offset.OffsetY = OffsetY;
        }
        //зміщує об'єкт на зазначену відстань по осі Z
        public void OffsetZ(double OffsetZ)
        {
            offset.OffsetZ = OffsetZ;
        }
        //цей метод створює трикутник за трьома точками(po,p1,p2) та додає його до полігональної сітки(mesh), а вершинам присвоюється номер починаючи з count.
        protected void CreateTriangleFace(Point3D po, Point3D p1, Point3D p2, MeshGeometry3D mesh, ref int count)
        {

            mesh.Positions.Add(po);
            mesh.Positions.Add(p1);
            mesh.Positions.Add(p2);
            mesh.TriangleIndices.Add(count);
            count++;
            mesh.TriangleIndices.Add(count);
            count++;
            mesh.TriangleIndices.Add(count);
            count++;
        }
    }
}
