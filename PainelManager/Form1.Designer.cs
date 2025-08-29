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
            flowLayoutPanel1 = new FlowLayoutPanel( );
            SuspendLayout( );
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point( 0, 0 );
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size( 1543, 554 );
            flowLayoutPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            ClientSize = new Size( 1543, 554 );
            Controls.Add( flowLayoutPanel1 );
            Icon = ( Icon ) resources.GetObject( "$this.Icon" );
            Name = "Form1";
            Text = "Troubleshoot";       
            ResumeLayout( false );

        }
        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
    }
}