using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOFD.Global.Interface;
using SOFD.Global.Manager;
using SOFD.Gui.Window;
using SOFD.Component;


namespace YANGSYS.UI.WHTM
{
    public partial class ucRecipePanel : UCFrame
    {
        RecipeDataList _RecipeDataList = new RecipeDataList();

        public ucRecipePanel()
        {
            InitializeComponent();
            tabControl1.SelectedIndex = 1;
        }

        private class CRecipeData
        {
            public List<string> Recipe { get; set; }

            public CRecipeData()
            {
                Recipe = new List<string>();
            }
            public bool SetValue<T>(string key, T value)
            {
                return true;
            }
        }

        private CRecipeData _RecipeData = new CRecipeData();
        CUpdateHandler<CRecipeData> UpdateRecipeHandler = null;

        public class CRecipeList
        {
            public SortedList<int, string> RecipeList { get; set; }
            public CRecipeList()
            {
                RecipeList = new SortedList<int, string>();
            }
        }

        CRecipeList _recipeList = new CRecipeList();
        CUpdateHandler<CRecipeList> UpdateRecipListHandler = null;

        private void InvokeUpdateRecipeData(bool noHandle, CRecipeData RecipeData)
        {
            if (RecipeData == null)
                return;

            UpdateRecipeHandler.Data = RecipeData;

            bool mExistFlag = false;
            int mRemoveCnt = 0;

            foreach (DataGridViewRow item in dgvPPIDRecipeMapView.Rows)
            {
                if (item.Cells["colPPID"].Value.ToString() == RecipeData.Recipe[0])
                {
                    if (RecipeData.Recipe[2] == "3")
                    {
                        mExistFlag = true;
                        break;
                    }
                    else
                    {
                        item.Cells["colPPID"].Value = RecipeData.Recipe[0];
                        item.Cells["colRecipeID"].Value = RecipeData.Recipe[1];
                        item.Cells["colCreateTime"].Value = RecipeData.Recipe[3];
                        item.Cells["colCreator"].Value = RecipeData.Recipe[4];
                        item.Cells["colDesc"].Value = RecipeData.Recipe[5] == "" ? item.Cells["colDesc"].Value : RecipeData.Recipe[5];
                    }

                    mExistFlag = true;
                    break;
                }
                mRemoveCnt += 1;
            }

            //for (int i = 0; i < dgvPPIDRecipeMapView.Rows.Count - 1; i++)
            //{
            //    if (dgvPPIDRecipeMapView.Rows[i].Cells["colPPID"].Value.ToString().ToUpper() == RecipeData.Recipe[0].ToUpper())
            //    {
            //        if (RecipeData.Recipe[2] == "3")
            //        {
            //            mRemoveCnt = i;
            //        }
            //        else
            //        {
            //            dgvPPIDRecipeMapView.Rows[i].Cells["colPPID"].Value = RecipeData.Recipe[0];
            //            dgvPPIDRecipeMapView.Rows[i].Cells["colRecipeID"].Value = RecipeData.Recipe[1];
            //            dgvPPIDRecipeMapView.Rows[i].Cells["colCreateTime"].Value = RecipeData.Recipe[3];
            //            dgvPPIDRecipeMapView.Rows[i].Cells["colCreator"].Value = RecipeData.Recipe[4];
            //            dgvPPIDRecipeMapView.Rows[i].Cells["colDesc"].Value = RecipeData.Recipe[5] == "" ? dgvPPIDRecipeMapView.Rows[i].Cells["colDesc"].Value : RecipeData.Recipe[5];
            //        }

            //        mExistFlag = true;
            //        break;
            //    }
            //}



            if (!mExistFlag)
            {
                DataGridViewRow oRow = dgvPPIDRecipeMapView.Rows[dgvPPIDRecipeMapView.Rows.Add()];

                oRow.Cells["colPPID"].Value = RecipeData.Recipe[0];
                oRow.Cells["colRecipeID"].Value = RecipeData.Recipe[1];
                oRow.Cells["colCreateTime"].Value = RecipeData.Recipe[3];
                oRow.Cells["colCreator"].Value = RecipeData.Recipe[4];
                oRow.Cells["colDesc"].Value = RecipeData.Recipe[5];

                comboBox1.Items.Add(RecipeData.Recipe[0]);
            }
            else
            {
                if (RecipeData.Recipe[2] == "3")
                {
                    if (mRemoveCnt > -1)
                    {
                        comboBox1.Items.Remove(dgvPPIDRecipeMapView.Rows[mRemoveCnt].Cells["colPPID"].Value);
                        dgvPPIDRecipeMapView.Rows.Remove(dgvPPIDRecipeMapView.Rows[mRemoveCnt]);
                    }
                }
            }

            _RecipeDataList.Count(dgvPPIDRecipeMapView.Rows.Count);

            if (dgvPPIDRecipeMapView.Rows.Count > 0)
            {
                int dCount = 0;
                foreach (DataGridViewRow item in dgvPPIDRecipeMapView.Rows)
                {
                    dCount++;
                    _RecipeDataList.Recipe_Save(dCount, item);
                }
            }
        }

        private void InvokeUpdateRecipeList(bool noHandle, CRecipeList mRecipeList)
        {
            if (mRecipeList == null)
                return;

            comboBox2.Items.Clear();

            foreach (var item in mRecipeList.RecipeList)
            {
                comboBox2.Items.Add(item.Key.ToString());
            }
            
        }

        public override bool Init()
        {
            base.Init();

            UpdateRecipeHandler = new CUpdateHandler<CRecipeData>(this, "UpdateRecipeData", ref _RecipeData);
            UpdateRecipeHandler.OnUpdateData = new CUpdateHandler<CRecipeData>.UpdateDataHandler(InvokeUpdateRecipeData);
            UpdateRecipeHandler.Subscribe();

            UpdateRecipListHandler = new CUpdateHandler<CRecipeList>(this, "UpdateRecipeList", ref _recipeList);
            UpdateRecipListHandler.OnUpdateData = new CUpdateHandler<CRecipeList>.UpdateDataHandler(InvokeUpdateRecipeList);
            UpdateRecipListHandler.Subscribe();
            return true;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("PPID Select Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow item in dgvPPIDRecipeMapView.Rows)
            {
                if (item.Cells["colPPID"].Value.ToString() == comboBox1.Text)
                {
                    MessageBox.Show("PPID Duplication Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            ACommand command = CUIManager.Inst.GetCommand("REQUEST");
            command.AddParameter("PPID", comboBox1.Text);
            command.AddParameter("RECIPEID", comboBox2.Text);
            command.AddParameter("PPCINFO", "1");
            command.AddParameter("TIME", DateTime.Now.ToString());
            command.AddParameter("USER", textBox2.Text);
            command.AddParameter("DESC", textBox1.Text);
            command.SubCommandName = "PPID_MAP_REPORT";
            command.Execute();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("PPID Select Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool mExistFlag = false;

            foreach (DataGridViewRow item in dgvPPIDRecipeMapView.Rows)
            {
                if (item.Cells["colPPID"].Value.ToString() == comboBox1.Text)
                {
                    ACommand command = CUIManager.Inst.GetCommand("REQUEST");
                    command.AddParameter("PPID", comboBox1.Text);
                    command.AddParameter("RECIPEID", comboBox2.Text);
                    command.AddParameter("PPCINFO", "4");
                    command.AddParameter("TIME", DateTime.Now.ToString());
                    command.AddParameter("USER", textBox2.Text);
                    command.AddParameter("DESC", textBox1.Text);
                    command.SubCommandName = "PPID_MAP_REPORT";
                    command.Execute();

                    mExistFlag = true;
                    break;
                }
            }

            if (!mExistFlag)
            {
                MessageBox.Show("PPID Exist Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            //bool mExistFlag = false;

            //foreach (DataGridViewRow item in dgvPPIDRecipeMapView.Rows)
            //{
            //    if (item.Cells["colPPID"].Value.ToString() == comboBox1.Text)
            //    {
                    
            //        mExistFlag = true;
            //        break;
            //    }
            //}

            //if (mExistFlag)
            //{
            //    MessageBox.Show("PPID Exist Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //ACommand command = CUIManager.Inst.GetCommand("REQUEST");
            //command.AddParameter("PPID", comboBox1.Text);
            //command.AddParameter("RECIPEID", comboBox2.Text);
            //command.AddParameter("PPCINFO", "4");
            //command.AddParameter("TIME", DateTime.Now.ToString());
            //command.AddParameter("USER", textBox2.Text);
            //command.AddParameter("DESC", textBox1.Text);
            //command.SubCommandName = "PPID_MAP_REPORT";
            //command.Execute();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("PPID Select Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ACommand command = CUIManager.Inst.GetCommand("REQUEST");
            command.AddParameter("PPID", comboBox1.Text);
            command.AddParameter("RECIPEID", comboBox2.Text);
            command.AddParameter("PPCINFO", "3");
            command.AddParameter("TIME", DateTime.Now.ToString());
            command.AddParameter("USER", textBox2.Text);
            command.AddParameter("DESC", textBox1.Text);
            command.SubCommandName = "PPID_MAP_REPORT";
            command.Execute();
        }

        private void btnUploadRecipe_Click(object sender, EventArgs e)
        {
            ACommand command = CUIManager.Inst.GetCommand("REQUEST");
            command.SubCommandName = "RECIPE_UPLOAD";
            command.Execute();
        }


        public class RecipeDataList : ACustomPropertyContainer
        {
            public RecipeDataList()
            {
            }

            public void Count(int dCount)
            {
                this.SetCustomProperty("PPID_MAP_LIST_COUNT", "COUNT", dCount.ToString(), "");
            }

            public void Recipe_Save(int dCount, DataGridViewRow item)
            {
                this.SetCustomProperty("PPID_MAP_LIST", dCount.ToString(), item.Cells["colPPID"].Value + "," + item.Cells["colRecipeID"].Value + ",," + item.Cells["colCreateTime"].Value + "," + item.Cells["colCreator"].Value + "," + item.Cells["colDesc"].Value, "");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TempPPID = comboBox1.SelectedItem.ToString();//.SelectedText;

            foreach (DataGridViewRow item in dgvPPIDRecipeMapView.Rows)
            {
                if (item.Cells["colPPID"].Value.ToString() == TempPPID)
                {
                    comboBox1.Text = TempPPID;
                    comboBox2.Text = item.Cells["colRecipeID"].Value.ToString();
                    textBox2.Text = item.Cells["colCreator"].Value.ToString();
                    textBox1.Text = item.Cells["colDesc"].Value.ToString();

                }
            }
        }

        private void dgvPPIDRecipeMapView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            comboBox1.Text = dgvPPIDRecipeMapView.Rows[e.RowIndex].Cells["colPPID"].Value.ToString();
            comboBox2.Text = dgvPPIDRecipeMapView.Rows[e.RowIndex].Cells["colRecipeID"].Value.ToString();
            textBox2.Text = dgvPPIDRecipeMapView.Rows[e.RowIndex].Cells["colCreator"].Value.ToString();
            textBox1.Text = dgvPPIDRecipeMapView.Rows[e.RowIndex].Cells["colDesc"].Value.ToString();
        }
    }
}
