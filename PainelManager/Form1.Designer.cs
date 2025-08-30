//namespace PainelManager
//{
//    partial class Form1
//    {

//        private System.ComponentModel.IContainer components = null;

//        protected override void Dispose( bool disposing )
//        {
//            if (disposing && ( components != null ))

//                components.Dispose( );

//            base.Dispose( disposing );
//        }

//        #region Windows Form Designer generated code


//        private void InitializeComponent()
//        {
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form1 ) );
//            flowLayoutPanel1 = new FlowLayoutPanel( );
//            SuspendLayout( );
//            // 
//            // flowLayoutPanel1
//            // 
//            flowLayoutPanel1.Dock = DockStyle.Fill;
//            flowLayoutPanel1.Location = new Point( 0, 0 );
//            flowLayoutPanel1.Name = "flowLayoutPanel1";
//            flowLayoutPanel1.Size = new Size( 1543, 554 );
//            flowLayoutPanel1.TabIndex = 0;
//            // 
//            // Form1
//            // 
//            ClientSize = new Size( 1543, 554 );
//            Controls.Add( flowLayoutPanel1 );
//            Icon = ( Icon ) resources.GetObject( "$this.Icon" );
//            Name = "Form1";
//            Text = "Troubleshoot";       
//            ResumeLayout( false );

//        }
//        #endregion
//        private FlowLayoutPanel flowLayoutPanel1;
//    }
//}


namespace PainelManager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose( bool disposing )
        {
            if (disposing && ( components != null ))
                components.Dispose( );
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form1 ) );
            this.tabControl1 = new TabControl( );
            this.tabTERM = new TabPage( );
            this.tabNETBOOT = new TabPage( );
            this.tabCONFIG = new TabPage( );
            this.flowTERM = new FlowLayoutPanel( );
            this.flowNETBOOT = new FlowLayoutPanel( );
            this.flowCONFIG = new FlowLayoutPanel( );
            this.tabControl1.SuspendLayout( );
            this.tabTERM.SuspendLayout( );
            this.tabNETBOOT.SuspendLayout( );
            this.tabCONFIG.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add( this.tabTERM );
            this.tabControl1.Controls.Add( this.tabNETBOOT );
            this.tabControl1.Controls.Add( this.tabCONFIG );
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Location = new Point( 0, 0 );
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size( 1543, 554 );
            this.tabControl1.TabIndex = 0;
            // 
            // tabTERM
            // 
            this.tabTERM.Controls.Add( this.flowTERM );
            this.tabTERM.Location = new Point( 4, 24 );
            this.tabTERM.Name = "tabTERM";
            this.tabTERM.Padding = new Padding( 3 );
            this.tabTERM.Size = new Size( 1535, 526 );
            this.tabTERM.TabIndex = 0;
            this.tabTERM.Text = "TERM";
            this.tabTERM.UseVisualStyleBackColor = true;
            // 
            // flowTERM
            // 
            this.flowTERM.Dock = DockStyle.Fill;
            this.flowTERM.Location = new Point( 3, 3 );
            this.flowTERM.Name = "flowTERM";
            this.flowTERM.Size = new Size( 1529, 520 );
            this.flowTERM.TabIndex = 0;
            // 
            // tabNETBOOT
            // 
            this.tabNETBOOT.Controls.Add( this.flowNETBOOT );
            this.tabNETBOOT.Location = new Point( 4, 24 );
            this.tabNETBOOT.Name = "tabNETBOOT";
            this.tabNETBOOT.Padding = new Padding( 3 );
            this.tabNETBOOT.Size = new Size( 1535, 526 );
            this.tabNETBOOT.TabIndex = 1;
            this.tabNETBOOT.Text = "NETBOOT";
            this.tabNETBOOT.UseVisualStyleBackColor = true;
            // 
            // flowNETBOOT
            // 
            this.flowNETBOOT.Dock = DockStyle.Fill;
            this.flowNETBOOT.Location = new Point( 3, 3 );
            this.flowNETBOOT.Name = "flowNETBOOT";
            this.flowNETBOOT.Size = new Size( 1529, 520 );
            this.flowNETBOOT.TabIndex = 0;
            // 
            // tabCONFIG
            // 
            this.tabCONFIG.Controls.Add( this.flowCONFIG );
            this.tabCONFIG.Location = new Point( 4, 24 );
            this.tabCONFIG.Name = "tabCONFIG";
            this.tabCONFIG.Padding = new Padding( 3 );
            this.tabCONFIG.Size = new Size( 1535, 526 );
            this.tabCONFIG.TabIndex = 2;
            this.tabCONFIG.Text = "CONFIG";
            this.tabCONFIG.UseVisualStyleBackColor = true;
            // 
            // flowCONFIG
            // 
            this.flowCONFIG.Dock = DockStyle.Fill;
            this.flowCONFIG.Location = new Point( 3, 3 );
            this.flowCONFIG.Name = "flowCONFIG";
            this.flowCONFIG.Size = new Size( 1529, 520 );
            this.flowCONFIG.TabIndex = 0;
            // 
            // Form1
            // 
            this.ClientSize = new Size( 1543, 554 );
            this.Controls.Add( this.tabControl1 );
            this.Icon = ( Icon ) resources.GetObject( "$this.Icon" );
            this.Name = "Form1";
            this.Text = "Troubleshoot";
            this.tabControl1.ResumeLayout( false );
            this.tabTERM.ResumeLayout( false );
            this.tabNETBOOT.ResumeLayout( false );
            this.tabCONFIG.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabTERM;
        private TabPage tabNETBOOT;
        private TabPage tabCONFIG;
        private FlowLayoutPanel flowTERM;
        private FlowLayoutPanel flowNETBOOT;
        private FlowLayoutPanel flowCONFIG;
    }
}
