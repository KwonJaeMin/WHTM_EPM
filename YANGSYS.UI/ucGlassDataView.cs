using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOFD.Logger;

namespace YANGSYS.UI.WHTM
{
    public delegate void delegateDataGridViewOneGlassView(int iGlassCode);
    public partial class ucGlassDataView : UserControl
    {


        public event delegateDataGridViewOneGlassView OnDataGridViewOneGlassView = null;

        #region //constructor's
        public ucGlassDataView()
        {
            InitializeComponent();

        }
        #endregion

        #region //member's

        #endregion

        #region //property's

        #endregion

        private string _UC_Title;

        public string UC_Title
        {
            get { return _UC_Title; }
            set { _UC_Title = value;
            this.lbTitle.Text = value;
            }
        }
        //private ComboBox _ComboEquipment;

        public ComboBox ComboEquipment
        {
            get { return this.cbEquipment; }
            set
            {
                this.cbEquipment = value;
            }
        }

        private void cbEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 아이템이 선택되면

            // 데이터 그리드뷰에 해당 데이터를 뿌려줘야한다.


            //============================
            // oGlass.CurrentLocation
            // 1~97 까지 포트
            // 98 robot (eqp unloading)
            // 99 robot (port unloading)
            // 100 
            // 101~xxx Eqp Stage
            //============================

            string selectControlName = cbEquipment.SelectedItem.ToString();

            SetDataGridView(selectControlName);

        }


        private void SetDataGridView(string selectControlName)
        {

            try
            {

                //int dataGridViewRowCount = 0;

                dataGridView1.Rows.Clear();
                //int GlasscurrentLocation = 0;

                //int start_currentLocation = 0; // 시작 점
                //int end_currentLocation = 0; // 종점
                //int eq_currentLocation = 0; // 같다면

                // Glass 범위를 지정해서 해당장비의 정보로 반환한다.
                //selectControlName.Substring
                //if (selectControlName.Contains("PORT"))
                //{
                //    foreach (CPortControl oPort in Main.Probes.Values)
                //    {
                //        if (oPort.ControlName.Contains(selectControlName))
                //        {
                //            eq_currentLocation = oPort.PortNo;
                //            break;
                //        }
                //    }
                //}
                //else if (selectControlName.Contains("STAGE"))
                //{
                //    foreach (CStageControl oStage in Main.Stages.Values)
                //    {
                //        if (oStage.ControlName.Contains(selectControlName))
                //        {
                //            eq_currentLocation = int.Parse(oStage.StageNo) + 100;
                //            break;
                //        }
                //    }
                //}
                //else if (selectControlName.Contains("ROBOT"))
                //{
                //    if (selectControlName.Contains("ROBOT01"))
                //    {
                //        eq_currentLocation = 98;
                //    }
                //    else if (selectControlName.Contains("ROBOT02"))
                //    {
                //        eq_currentLocation = 99;
                //    }
                //}

                //foreach (CGlassDataProperties oGlass in Main.GlassDatas.Values)
                //{
                //    GlasscurrentLocation = int.Parse(oGlass.CurrentLocation);
                //    if (GlasscurrentLocation == eq_currentLocation)
                //    {
                //        dataGridView1.Rows.Add();
                //        DataGridViewRow row = null;

                //        row = dataGridView1.Rows[dataGridViewRowCount];
                //        row.Cells["GlassID"].Value = oGlass.GlassID;
                //        row.Cells["GlassCode"].Value = oGlass.GlassCode;

                //        dataGridViewRowCount++;
                //    }
                //}
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
                //throw;
            }
        }


        private void btnDeleteSelect_Click(object sender, EventArgs e)
        {
            //if (Main == null)
            //    return;

            //CGlassDataProperties oGlass = null;

            //if (ShowCheckConfirm("Glass Data 삭제", "정말 삭제하시겠습니까?"))
            //{

            //    for (int i = 0; i < objSelectItem.Length; i++)
            //    {
            //        if (objSelectItem[i] != null)
            //        {
            //            try
            //            {

            //                int GlassCode = int.Parse(objSelectItem[i].ToString());
            //                oGlass = Main.GlassDatas[GlassCode];
            //                oGlass.Delete();

            //                Main.GlassDatas.Remove(GlassCode);
            //            }
            //            catch (Exception ex)
            //            {
            //                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
            //                //throw;
            //            }
            //        }
            //    }



            //    // 화면 리플래쉬
            //    if (cbEquipment.SelectedItem != null) // 1106 이진우 추가
            //    {
            //        string selectControlName = cbEquipment.SelectedItem.ToString();

            //        SetDataGridView(selectControlName);
            //    }
            //    else
            //    {
            //        MessageBox.Show("값이 선택 되지 않았습니다.");
            //    }
            //}
        }
        public bool ShowCheckConfirm(string vTitle, string vText)
        {
            frmConfirm fConfirm = new frmConfirm();
            fConfirm.SetContent(vTitle, vText);

            fConfirm.TopMost = true;
            fConfirm.ShowDialog(this);
            if (fConfirm.CheckReturn)
            {
                fConfirm.TopMost = false;
                return true;
            }
            else
            {
                fConfirm.TopMost = true;
                return false;
            }
        }

        private void dataGridView1_MultiSelectChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("");
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 셀클릭시 GlassCode로 dataGridViewOneGlass 데이터를 뿌려준다.
            //Console.WriteLine(dataGridView1.SelectedCells.ToString());
            try
            {
                if (e.RowIndex > 0)
                {
                    DataGridViewRow oRow = dataGridView1.Rows[e.RowIndex];
                    // Console.WriteLine(oRow.Cells["GlassCode"].Value);

                    if (OnDataGridViewOneGlassView != null)
                        OnDataGridViewOneGlassView(int.Parse(oRow.Cells["GlassCode"].Value.ToString()));
                }
            }
            catch (Exception)
            {
                
                throw;
            }
 

        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //Console.WriteLine("");
        }


        //============================================================
        // 2013-09-09 김동광K 포커스가 벗어나면 selected가 되지 않는다.
        // 선택될때 GlassCode를 어디에 담아놓자.
        // 완료후엔 초기화 되어야 한다.
        //============================================================
        public object[] objSelectItem = new object[1000];//최대 담을수 있는개수를 넣어야한다.

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("");
            //dataGridView1.MultiSelect.ToString();
            //Console.WriteLine(dataGridView1.SelectedCells.Count);

            for (int i = 0; i < objSelectItem.Length; i++)
            {
                objSelectItem[i] = null;
            }
            int iplus = 0;
            foreach (DataGridViewCell item in dataGridView1.SelectedCells)
            {
                //Console.WriteLine(item.RowIndex.ToString());

                DataGridViewRow row = null;
                row = dataGridView1.Rows[item.RowIndex];
                Console.WriteLine(row.Cells["GlassCode"].Value);

                objSelectItem[iplus] = row.Cells["GlassCode"].Value;
                iplus++;
            }

            //Console.WriteLine("");

            //row = dataGridView1.Rows[dataGridViewRowCount];
            //row.Cells["GlassID"].Value = oGlass.GlassID;
            //row.Cells["GlassCode"].Value = oGlass.GlassCode;

        }


    }
}
