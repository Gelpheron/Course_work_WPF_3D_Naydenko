using System;
using System.Collections.Generic;
using System.Text;
using Курсова_робота_Найденко_Влад__10_А;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Collections.ObjectModel;
using _3DTools;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Курсова_робота_Найденко_Влад__10_А
{
    /// <summary>
    /// Interaction logic for Project.xaml
    /// </summary>
    public partial class Project : Window
    {
        public static ObservableCollection<string> ShapesCollectionNames = new ObservableCollection<string>();
        public static Dictionary<string, Shapes> Figures = new Dictionary<string, Shapes>();
        public Project()
        {
            InitializeComponent();
            NamesOfShapes.ItemsSource = ShapesCollectionNames;
            model.Content = All;
            ScreenSpaceLines3D Zax = new ScreenSpaceLines3D();
            Zax.Points.Add(new Point3D(0, 0, 0));
            Zax.Points.Add(new Point3D(0, 0, 3));
            Zax.Color = Colors.Blue;
            Zax.Thickness = 2;
            ScreenSpaceLines3D Yax = new ScreenSpaceLines3D();
            Yax.Points.Add(new Point3D(0, 0, 0));
            Yax.Points.Add(new Point3D(0, 3, 0));
            Yax.Color = Colors.Green;
            Yax.Thickness = 2;
            ScreenSpaceLines3D Xax = new ScreenSpaceLines3D();
            Xax.Points.Add(new Point3D(0, 0, 0));
            Xax.Points.Add(new Point3D(3, 0, 0));
            Xax.Color = Colors.Red;
            Xax.Thickness = 2;
            myViewport.Children.Add(Zax);
            myViewport.Children.Add(Yax);
            myViewport.Children.Add(Xax);
        }
        Shapes SelectedObject;
        DataTorusWindow TorusPaintWindow;
        DataSphere SpherePaintWindow;
        DataCylinder CylinderPaintWindow;
        ConDataPaintWindow ConePaintWindow;
        public static Model3DGroup All = new Model3DGroup();
        #region Sphere
        private void RibbonButton_SphereClick(object sender, RoutedEventArgs e)
        {
            SpherePaintWindow = new DataSphere();
            SpherePaintWindow.Show();
            SpherePaintWindow.Start.Click += Button_SphereCreate;
        }
        private void Button_SphereCreate(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(SpherePaintWindow.RadiusSphere.Text, out double InRadiusSphere))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!double.TryParse(SpherePaintWindow.SphereCenterX.Text, out double InSphereCenterX))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!double.TryParse(SpherePaintWindow.SphereCenterY.Text, out double InSphereCenterY))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!double.TryParse(SpherePaintWindow.SphereCenterZ.Text, out double InSphereCenterZ))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (SpherePaintWindow.ColorPicker1.SelectedColor == null)
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!int.TryParse(SpherePaintWindow.uText.Text, out int u))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!int.TryParse(SpherePaintWindow.vText.Text, out int v))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            string str = SpherePaintWindow.nameShape.Text;
            if (ShapesCollectionNames.Contains(str)|| String.IsNullOrWhiteSpace(str))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            Figures.Add(str, new Sphere(new Point3D(InSphereCenterX, InSphereCenterY, InSphereCenterZ), InRadiusSphere,u,v, (Color)SpherePaintWindow.ColorPicker1.SelectedColor, ref All));
            ShapesCollectionNames.Add(SpherePaintWindow.nameShape.Text);
            SpherePaintWindow.Close();
        }
        #endregion

        #region Cylinder
        private void RibbonButton_CylinderClick(object sender, RoutedEventArgs e)
        {
            CylinderPaintWindow = new DataCylinder();
            CylinderPaintWindow.Show();
            CylinderPaintWindow.ButtonCreateCylinder.Click += Button_CreateCylinder;
        }
        private void Button_CreateCylinder(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(CylinderPaintWindow.CylinderRadius.Text, out double InRadiusCylinder))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!double.TryParse(CylinderPaintWindow.CylinderHeight.Text, out double InHeightCylinder))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!double.TryParse(CylinderPaintWindow.CylinderCenterX.Text, out double InCylinderCenterX))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!double.TryParse(CylinderPaintWindow.CylinderCenterY.Text, out double InCylinderCenterY))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!double.TryParse(CylinderPaintWindow.CylinderCenterZ.Text, out double InCylinderCenterZ))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (CylinderPaintWindow.ColorPicker1.SelectedColor == null)
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!int.TryParse(CylinderPaintWindow.nTextBox.Text, out int n))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!double.TryParse(CylinderPaintWindow.CylinderRadiusIn.Text, out double rin))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            string str = CylinderPaintWindow.CylinderName.Text;
            if (ShapesCollectionNames.Contains(str) || String.IsNullOrWhiteSpace(str))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            Figures.Add(str, new Cylinder(new Point3D(InCylinderCenterX, InCylinderCenterY, InCylinderCenterZ),rin, InHeightCylinder, InRadiusCylinder,n, (Color)CylinderPaintWindow.ColorPicker1.SelectedColor, ref All));
            ShapesCollectionNames.Add(CylinderPaintWindow.CylinderName.Text);
            CylinderPaintWindow.Close();
        }

        #endregion

        private void RibbonButton_ConeClick(object sender, RoutedEventArgs e)
        {
            ConePaintWindow = new ConDataPaintWindow();
            ConePaintWindow.Show();
            ConePaintWindow.ConeCreate.Click += Button_CreateCone;
        }
        private void Button_CreateCone(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(ConePaintWindow.ConeRadius.Text, out double InRadiusCone))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!double.TryParse(ConePaintWindow.ConeHeight.Text, out double InHeightCone))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!double.TryParse(ConePaintWindow.ConeCenterX.Text, out double InConeCenterX))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!double.TryParse(ConePaintWindow.ConeCenterY.Text, out double InConeCenterY))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!double.TryParse(ConePaintWindow.ConeCenterZ.Text, out double InConeCenterZ))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (ConePaintWindow.ColorPicker1.SelectedColor == null)
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!int.TryParse(ConePaintWindow.ConeVertexRadius.Text, out int InConeVertexRadius))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!int.TryParse(ConePaintWindow.ConeEdgeNumber.Text, out int InConeEdgeNumber))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            string str = ConePaintWindow.ConeName.Text;
            if (ShapesCollectionNames.Contains(str) || String.IsNullOrWhiteSpace(str))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            Figures.Add(str, new Cone(InRadiusCone, InConeVertexRadius, InHeightCone, InConeEdgeNumber, new Point3D(InConeCenterX, InConeCenterY, InConeCenterZ), (Color)ConePaintWindow.ColorPicker1.SelectedColor, ref All));
            ShapesCollectionNames.Add(ConePaintWindow.ConeName.Text);
            ConePaintWindow.Close();
        }

        private void RibbonButton_TorusClick(object sender, RoutedEventArgs e)
        {
            TorusPaintWindow = new DataTorusWindow();
            TorusPaintWindow.Show();
            TorusPaintWindow.TorusCreate.Click += Button_CreateTorus;
        }
        private void Button_CreateTorus(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(TorusPaintWindow.RTorus.Text, out double InRadiusTorus))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!double.TryParse(TorusPaintWindow.rTorus.Text, out double InradTorus))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!int.TryParse(TorusPaintWindow.NTorus.Text, out int InNTorus))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!int.TryParse(TorusPaintWindow.nTorus.Text, out int InnTorus))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!double.TryParse(TorusPaintWindow.TorusCenterX.Text, out double InCenterXTorus))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!double.TryParse(TorusPaintWindow.TorusCenterY.Text, out double InCenterYTorus))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (!double.TryParse(TorusPaintWindow.TorusCenterZ.Text, out double InCenterZTorus))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            if (TorusPaintWindow.ColorPicker1.SelectedColor == null)
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            string str = TorusPaintWindow.TorusName.Text;
            if (ShapesCollectionNames.Contains(str) || String.IsNullOrWhiteSpace(str))
            {
                MessageBox.Show("Введені данні невалідні");
                return;
            }
            Figures.Add(str, new Torus(new Point3D(InCenterXTorus, InCenterYTorus, InCenterZTorus), InRadiusTorus, InradTorus, InNTorus, InnTorus, (Color)TorusPaintWindow.ColorPicker1.SelectedColor, ref All));
            ShapesCollectionNames.Add(TorusPaintWindow.TorusName.Text);
            TorusPaintWindow.Close();
        }
        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            if(Keyboard.IsKeyDown(Key.Right))
            {
                visionX.Angle++;
            }
            if (Keyboard.IsKeyDown(Key.Left))
            {
                visionX.Angle--;
            }
            if (Keyboard.IsKeyDown(Key.Up))
            {
                visionY.Angle--;
            }
            if (Keyboard.IsKeyDown(Key.Down))
            {
                visionY.Angle++;
            }

        }
        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                Zoom.ScaleX += 0.1;
                Zoom.ScaleY += 0.1;
                Zoom.ScaleZ += 0.1;
            }
            if (e.Delta < 0 && !(Zoom.ScaleX <= 0.2))
            {
                Zoom.ScaleX -= 0.1;
                Zoom.ScaleY -= 0.1;
                Zoom.ScaleZ -= 0.1;
            }

        }

        private void ClickBackProject(object sender, RoutedEventArgs e)
        {
            MainWindow mainWind = new MainWindow();
            mainWind.Show();
            base.Close();
        }

        private void ScaleX_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(SelectedObject!=null)
            {
                if (double.TryParse(ScaleX.Text, NumberStyles.Any, new NumberFormatInfo { NumberDecimalSeparator = "." }, out double p))
                {
                    SelectedObject.ScaleX(p);
                }
            }
        }

        private void ScaleY_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SelectedObject != null)
            {
                if (double.TryParse(ScaleY.Text, NumberStyles.Any, new NumberFormatInfo { NumberDecimalSeparator = "." }, out double p))
                {
                    SelectedObject.ScaleY(p);
                }
            }
        }

        private void ScaleZ_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SelectedObject != null)
            {
                if (double.TryParse(ScaleZ.Text, NumberStyles.Any, new NumberFormatInfo { NumberDecimalSeparator = "." }, out double p))
                {
                    SelectedObject.ScaleZ(p);
                }
            }
        }

        private void RotateX_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SelectedObject != null)
            {
                if (double.TryParse(RotateX.Text, NumberStyles.Any, new NumberFormatInfo { NumberDecimalSeparator = "." }, out double p))
                {
                    SelectedObject.RotateX(p);
                }
            }
        }

        private void RotateY_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SelectedObject != null)
            {
                if (double.TryParse(RotateY.Text, NumberStyles.Any, new NumberFormatInfo { NumberDecimalSeparator = "." }, out double p))
                {
                    SelectedObject.RotateY(p);
                }
            }
        }

        private void RotateZ_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SelectedObject != null)
            {
                if (double.TryParse(RotateZ.Text, NumberStyles.Any, new NumberFormatInfo { NumberDecimalSeparator = "." }, out double p))
                {
                    SelectedObject.RotateZ(p);
                }
            }
        }
        private void OffsetX_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SelectedObject != null)
            {
                if (double.TryParse(OffsetX.Text, NumberStyles.Any, new NumberFormatInfo { NumberDecimalSeparator = "." }, out double p))
                {
                    SelectedObject.OffsetX(p);
                }
            }
        }
        private void OffsetY_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SelectedObject != null)
            {
                if (double.TryParse(OffsetY.Text, NumberStyles.Any, new NumberFormatInfo { NumberDecimalSeparator = "." }, out double p))
                {
                    SelectedObject.OffsetY(p);
                }
            }
        }
        private void OffsetZ_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SelectedObject != null)
            {
                if (double.TryParse(OffsetZ.Text, NumberStyles.Any, new NumberFormatInfo { NumberDecimalSeparator = "." }, out double p))
                {
                    SelectedObject.OffsetZ(p);
                }
            }
        }
        private void NamesOfShapes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Figures.TryGetValue(comboBox.SelectedItem.ToString(), out SelectedObject);
        }
    }
}
