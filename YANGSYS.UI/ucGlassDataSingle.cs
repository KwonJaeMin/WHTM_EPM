using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YANGSYS.UI.WHTM
{
    public partial class ucGlassDataSingle : UserControl
    {
        #region //member's
        private string _lotID = string.Empty;
        private string _glassID = string.Empty;
        private string _recipe = string.Empty;
        private string _glassType = string.Empty;
        private string _glassCode = string.Empty;
        private string _glassJudge = string.Empty;
        #endregion

        #region //property's
        public string LotID
        {
            get { return _lotID; }
            set
            {
                _lotID = value;
                this.txtLotID.Text = _lotID;
                Invalidate();
            }
        }
        public string GlassID
        {
            get { return _glassID; }
            set
            {
                _glassID = value;
                this.txtGlassID.Text = _glassID;
                Invalidate();
            }
        }
        public string Recipe
        {
            get { return _recipe; }
            set
            {
                _recipe = value;
                this.txtRecipe.Text = _recipe;
                Invalidate();
            }
        }
        public string GlassType
        {
            get { return _glassType; }
            set
            {
                _glassType = value;
                this.txtGlassType.Text = _glassType;
                Invalidate();
            }
        }
        public string GlassCode
        {
            get { return _glassCode; }
            set
            {
                _glassCode = value;
                this.txtGlassCode.Text = _glassCode;
                Invalidate();
            }
        }
        public string GlassJudge
        {
            get { return _glassJudge; }
            set
            {
                _glassJudge = value;
                this.txtJudge.Text = _glassJudge;
                Invalidate();
            }
        }
        #endregion

        #region //constructor's
        public ucGlassDataSingle()
        {
            InitializeComponent();
        }
        #endregion
    }
}
