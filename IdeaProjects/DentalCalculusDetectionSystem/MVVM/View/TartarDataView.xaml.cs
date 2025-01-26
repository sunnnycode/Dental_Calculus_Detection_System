using System;
using System.Drawing;
using System.Windows.Controls;
using System.Windows;

namespace WPFtartarUI.MVVM.View
{
    /// <summary>
    /// TartarDataView.xaml에 대한 상호 작용 논리
    /// </summary>
   
    [ToolboxBitmap(typeof(Button),"Tartarbtn")]
    public partial class TartarDataView : UserControl
    { 
        
        public TartarDataView()
        {
            InitializeComponent();
        }

        private void Tartarbtn_Click(object sender, RoutedEventArgs e)
        {
            
            /*Bitmap bitmap = new Bitmap();

            bitmap = img as Bitmap;           

            int width = bitmap.Width;
            int height = bitmap.Height;


            Color colorData;

            for (int i = 0; i < width; i++)

            {

                for (int j = 0; j < height; j++)

                {

                    colorData = bitmap.GetPixel(i, j);
                    RColorConvert(ref colorData);
                    bitmap.SetPixel(i, j, colorData);

                }

            }*/
            
        }

        private void RColorConvert(ref Color src)

        {

            if (src.B > 90)
            {
                src = Color.FromArgb(255, 255, 255);
                
            }

            else if (src.G > 130)
            {
                src = Color.FromArgb(255, 51, 153);
                
            }
            else
            {
                int res = (src.R + src.G + src.B) / 3;

                src = Color.FromArgb(res, res, res);

            }


        }






    }
}

