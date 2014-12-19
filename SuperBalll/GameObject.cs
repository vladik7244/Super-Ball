using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace SuperBalll
{
    abstract class GameObject
    {
        bool isVisible=true;
        /// <summary>
        /// Видимй ли объект
        /// </summary>
        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }
        PointF location = new PointF(0, 0);
        /// <summary>
        /// Координаты объекта
        /// </summary>
        public PointF Location
        {
            get { return location; }
            set { location = value; }
        }

        private PointF speed = new PointF(0, 0);
        /// <summary>
        /// Вектор скорости объекта
        /// </summary>
        public PointF Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        private PointF acceleration= new PointF(0,0);
        /// <summary>
        /// Вектор ускорения
        /// </summary>
        public PointF Acceleration
        {
            get { return acceleration; }
            set { acceleration = value; }
        }
      
      
        /// <summary>
        /// Функция рисования конкретного объекта (переопределяется во всех наследниках)
        /// </summary>
        /// <param name="g">Графика, которая используется для рисования</param>
        public abstract void Draw(Graphics g);
        /// <summary>
        /// Действия, которые выполняются с каждым шагом игры
        /// </summary>
        public virtual void Step()
        {
            speed.X += Acceleration.X;
            speed.Y += Acceleration.Y;
            location.X += Speed.X;
            location.Y += Speed.Y;
            
        }

        /// <summary>
        /// Создает пустой эеземпляр объекта
        /// </summary>
        public GameObject()
        {
            this.Location = new PointF(0, 0);
        }

        public virtual void KeyUp(Keys key)
        {

        }
        public virtual void KeyDown(Keys key)
        {

        }
        public virtual void MouseUp(MouseButtons mb,Point loc)
        {

        }
        public virtual void MouseDown(MouseButtons mb,Point loc)
        {

        }
    }
}
