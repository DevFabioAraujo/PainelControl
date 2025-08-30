using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PainelManager
{
    public partial class Form1 : Form
    {
        //Caminho dos executaveis
       // private readonly string diretorio = @"C:\ProgramasExternos";
        private readonly string dirTERM = @"C:\Programas\TERM\";
        private readonly string dirNETBOOT = @"C:\Programas\NETBOOT";
        private readonly string dirCONFIG = @"C:\Programas\CONFIG";

        public Form1()
        {
            InitializeComponent( );
            CarregarProgramas( );
        }

        private void Form1_Load( object sender, EventArgs e )
        {

        }

        private void CarregarProgramas()
        {
            CarregarExecutaveis( dirTERM, flowTERM );
            CarregarExecutaveis( dirNETBOOT, flowNETBOOT );
            CarregarExecutaveis( dirCONFIG, flowCONFIG );
        }

                private void CarregarExecutaveis( string diretorio, FlowLayoutPanel painel )
                {
                    if (!Directory.Exists( diretorio )) return;

                        //.exe e .lnk
                        string [ ]arquivos = Directory.GetFiles( diretorio,"*.*").Where(f=>f.EndsWith(".exe")||f.EndsWith(".lnk")).ToArray();

                        foreach (var arquivo in arquivos) 
                        {
                            var btn = new Button
                            {
                                Text = Path.GetFileNameWithoutExtension( arquivo ),
                                Width = 200,
                                Height = 150,
                                Tag = arquivo
                            };
                            btn.Click += ExecutarPrograma;
                            painel.Controls.Add( btn );

                        }
                    
                }      
    

        private void ExecutarPrograma( object? sender, EventArgs e )
        {
            if (sender is Button btn && btn.Tag is string caminho)
            {
                try
                {
                    Process.Start( new ProcessStartInfo
                    {
                        FileName = caminho,
                        UseShellExecute = true //Necessario no .Net 8
                    } );
                }
                catch (Exception ex)
                {
                    MessageBox.Show( $"Erro ao executar:{ex.Message}" );
                }
            }

        }
    }
}
