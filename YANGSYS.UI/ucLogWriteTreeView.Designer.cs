using SOFD.Logger;
namespace YANGSYS.UI.WHTM
{
    partial class ucLogWriteTreeView
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            //KIMSHINHYO - 20121210 Memory 증가문제로 인해 이벤트 해제 추가
            if (CLogManager.Instance != null && _logBinding == false)
            {
                _logBinding = true;
                CLogManager.Instance.LogQueued -= new LogQueuedEventHandler(Instance_LogQueued);
            }

            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeViewLogSpy = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeViewLogSpy
            // 
            this.treeViewLogSpy.BackColor = System.Drawing.Color.Black;
            this.treeViewLogSpy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewLogSpy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewLogSpy.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.treeViewLogSpy.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.treeViewLogSpy.FullRowSelect = true;
            this.treeViewLogSpy.Indent = 10;
            this.treeViewLogSpy.Location = new System.Drawing.Point(2, 2);
            this.treeViewLogSpy.Name = "treeViewLogSpy";
            this.treeViewLogSpy.ShowPlusMinus = false;
            this.treeViewLogSpy.Size = new System.Drawing.Size(865, 93);
            this.treeViewLogSpy.TabIndex = 0;
            this.treeViewLogSpy.Enter += new System.EventHandler(this.treeViewLogSpy_Enter);
            this.treeViewLogSpy.Leave += new System.EventHandler(this.treeViewLogSpy_Leave);
            this.treeViewLogSpy.MouseHover += new System.EventHandler(this.treeViewLogSpy_MouseHover);
            this.treeViewLogSpy.Click += new System.EventHandler(this.treeViewLogSpy_Click);
            // 
            // ucLogWriteTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.treeViewLogSpy);
            this.Name = "ucLogWriteTreeView";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(869, 97);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewLogSpy;
    }
}
