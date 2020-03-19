using System.Collections.Generic;
using System.Drawing;

namespace Models.Concrete
{
    public class OrangeRicky : Rectangle
    {
        public override Color Color { get; set; } = Color.Orange;

        public OrangeRicky()
        {
            GenerateOrangeRicky();
        }

        public OrangeRicky(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
            this.Xposition = Xposition;
            this.Yposition = Xposition;
        }


        //Creates Initial Ricky
        private void GenerateOrangeRicky()
        {
           
            for (int i = 0; i <= 4; i++)
            {
               if(i==4)
               {
                    rects.Add(new Rectangle(rects[3].Xposition + 10, rects[3].Yposition - Width, Width,Height));
               }
               rects.Add(new Rectangle(Xposition + i*10, Yposition + Width, Width, Height));
            }

        }
    }
}
