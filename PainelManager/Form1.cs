using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PainelManager
{
    public partial class Form1 : Form
    {
        //Caminho dos executaveis
        private readonly string diretorio = @"C:\ProgramasExternos";
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
            if (!Directory.Exists( diretorio ))
            {

                MessageBox.Show( $"Diretorio não encontrado:{diretorio}" );
                return;
            }
            //Pega tanto .exe e .lnk
            string [ ] arquivos = Directory.GetFiles( diretorio, "*.*" )
                .Where(f=>f.EndsWith(".exe")|| f.EndsWith(".lnk")).ToArray();

            foreach (var arquivo in arquivos)
            {
                var btn = new Button
                {
                    Text = Path.GetFileNameWithoutExtension( arquivo ),
                    Width = 200,
                    Height = 100,
                    Tag = arquivo
                };

                btn.Click += ExecutarPrograma;
                flowLayoutPanel1.Controls.Add( btn );

            }
        }

        private void ExecutarPrograma( object? sender, EventArgs e )
        {
            if (sender is Button btn && btn.Tag is string caminhoExe)
            {
                try
                {
                    Process.Start( new ProcessStartInfo
                    {
                        FileName = caminhoExe,
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
