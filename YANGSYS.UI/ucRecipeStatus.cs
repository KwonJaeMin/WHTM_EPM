using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOFD.Gui.Widget;
using SOFD.Global.Manager;

namespace YANGSYS.UI.WHTM
{
    public partial class ucRecipeStatus : UCBaseObject
    {
        public ucRecipeStatus()
        {
            InitializeComponent();
        }

        public class CRecipeList
        {
            public SortedList<int, string> RecipeList { get; set; }
            public CRecipeList()
            {
                RecipeList = new SortedList<int, string>();
            }
        }

        CRecipeList _recipeList = new CRecipeList();

        public override bool Init()
        {
            base.Init();

            CUpdateHandler<CRecipeList> UpdateHandler = null;
            UpdateHandler = new CUpdateHandler<CRecipeList>(this, "ucRecipeStatus", ref _recipeList);
            UpdateHandler.OnUpdateData = new CUpdateHandler<CRecipeList>.UpdateDataHandler(InvokeUpdateData);
            UpdateHandler.Subscribe();
            return true;
        }

        private void InvokeUpdateData(bool noHandle, CRecipeList cimStatusData)
        {
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            Graphics g = Graphics.FromImage(bitmap);
            int columnCount = 32;
            int width = this.Width / columnCount;
            int height = this.Height / columnCount;
            for (int i = 0; i < 1000; i++) //999
            {
                this.DrawRecipeBox(g, i, columnCount, width, height, cimStatusData.RecipeList.ContainsKey(i));
            }
            if(this.BackgroundImage != null)
                this.BackgroundImage.Dispose();

            this.BackgroundImage = bitmap;

            g.Dispose();
        }

        private void DrawRecipeBox(Graphics g, int recipeNo, int maxColumnCount, int width, int height, bool on)
        {
            Size fontSize = TextRenderer.MeasureText(recipeNo.ToString(), this.Font);
            Brush backColor = on ? Brushes.Lime : Brushes.DarkGray;
            int x = 0, y = 0;
            int row = 0, column = 0;
            row = (recipeNo / maxColumnCount);
            column = (recipeNo % maxColumnCount);
            Console.WriteLine(string.Format("{0},{1}", row, column));
            x = column * width;// (width + 2);
            y = row * height; // (height + 2);
            g.FillRectangle(backColor, x, y, width, height);
            g.DrawRectangle(Pens.Black, x, y, width, height);
            if (on)
                g.DrawString(recipeNo.ToString(), this.Font, Brushes.Black, x + (width / 2f - fontSize.Width / 2f) + 1, y + (height / 2f - fontSize.Height / 2f));
        }
    }
}
