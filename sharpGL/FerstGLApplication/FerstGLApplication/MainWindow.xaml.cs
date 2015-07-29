using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SharpGL.SceneGraph;
using SharpGL;

namespace FerstGLApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Handles the OpenGLDraw event of the openGLControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="SharpGL.SceneGraph.OpenGLEventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLDraw(object sender, OpenGLEventArgs args)
        {
            int H;
            //  Получаемт ссылку на элемент управления OpenGL 
            OpenGL gl = openGLControl.OpenGL;
            //получаем высоту окна 
            H =  (int)this.Height;
            //вычитаем высоту текста
            H -= 65;
            //  Очищает буфер кадра 
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //  загружает нулевую матрицу мировых координат
            gl.LoadIdentity();
            gl.DrawText(0, H, 1, 1, 1, "", 20, "Score: 00000" );
            //  поворачивает сцену по оси Y на определенный угол
            
        }

        /// <summary>
        /// Handles the OpenGLInitialized event of the openGLControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="SharpGL.SceneGraph.OpenGLEventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLInitialized(object sender, OpenGLEventArgs args)
        {
            //  TODO: Initialise OpenGL here.

            //  получаем ссылку на окно OpenGL 
            OpenGL gl = openGLControl.OpenGL;

            
            //  Задаем цвет очистки экрана
            gl.ClearColor(0, 0, 0, 0);
        }

        /// <summary>
        /// Handles the Resized event of the openGLControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="SharpGL.SceneGraph.OpenGLEventArgs"/> instance containing the event data.</param>
        private void openGLControl_Resized(object sender, OpenGLEventArgs args)
        {
            //  TODO: Set the projection matrix here.

            //  получаем ссылку на окно OpenGL 
            OpenGL gl = openGLControl.OpenGL;

            //  Задаем матрицу вида 
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  загружаем нулевую матрицу сцены
            gl.LoadIdentity();

            //  подгоняем окно просмотра под размеры окна OpenGL в форме 
            gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);

            //  Задаем координаты камеры куда она будет смотреть 
            gl.LookAt(-5, 5, -5, 0, 0, 0, 0, 1, 0);

            //  задаем матрицу вида мдели 
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        /// <summary>
        /// Описываем угол поворота сцены по умолчанию 0
        /// </summary>
       
    }
}
