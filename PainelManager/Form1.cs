using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using IWshRuntimeLibrary; // Referência COM: Windows Script Host Object Model

namespace PainelManager
{
    public partial class Form1 : Form
    {
        // Diretórios de cada categoria
        private readonly string dirTERM = @"C:\Programas\TERM\";
        private readonly string dirNETBOOT = @"C:\Programas\NETBOOT";
        private readonly string dirCONFIG = @"C:\Programas\CONFIG";
        private readonly string dirESQUEMAELETRICOS = @"C:\Programas\ESQELETRICO";

        public Form1()
        {
            InitializeComponent( );
            CarregarProgramas( );
        }

        private void CarregarProgramas()
        {
            CarregarExecutaveis( dirTERM, flowTERM );
            CarregarExecutaveis( dirNETBOOT, flowNETBOOT );
            CarregarExecutaveis( dirCONFIG, flowCONFIG );
            CarregarExecutaveis( dirESQUEMAELETRICOS, flowESQELETRICO );
        }

        private void CarregarExecutaveis( string diretorio, FlowLayoutPanel painel )
        {
            if (!Directory.Exists( diretorio )) return;

            string [ ] arquivos = Directory.GetFiles( diretorio, "*.*" )
                .Where( f => f.EndsWith( ".exe" ) || f.EndsWith( ".lnk" ) || f.EndsWith( ".pdf" ) )
                .ToArray( );

            foreach (var arquivo in arquivos)
            {
                var btn = new Button
                {
                    Text = Path.GetFileNameWithoutExtension( arquivo ),
                    Width = 120,
                    Height = 120,
                    Tag = arquivo,
                    TextAlign = ContentAlignment.BottomCenter,
                    ImageAlign = ContentAlignment.TopCenter
                };

                // Tooltip com caminho completo
                ToolTip tt = new ToolTip( );
                tt.SetToolTip( btn, arquivo );

                try
                {
                    string caminhoReal = arquivo;

                    // Se for atalho .lnk, resolve o caminho real
                    if (Path.GetExtension( arquivo ).ToLower( ) == ".lnk")
                    {
                        caminhoReal = GetShortcutTarget( arquivo );
                    }

                    if (System.IO.File.Exists( caminhoReal ))
                    {
                        Icon icone = Icon.ExtractAssociatedIcon( caminhoReal );
                        if (icone != null)
                        {
                            // Redimensiona ícone para caber no botão
                            btn.Image = new Bitmap( icone.ToBitmap( ), new Size( 48, 48 ) );
                        }
                    }
                }
                catch
                {
                    // Se falhar, ignora
                }

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
                    string caminhoReal = caminho;

                    if (Path.GetExtension( caminho ).ToLower( ) == ".lnk")
                    {
                        caminhoReal = GetShortcutTarget( caminho );
                    }

                    Process.Start( new ProcessStartInfo
                    {
                        FileName = caminhoReal,
                        UseShellExecute = true
                    } );
                }
                catch (Exception ex)
                {
                    MessageBox.Show( $"Erro ao executar: {ex.Message}" );
                }
            }
        }

        // Função que pega o caminho real do atalho .lnk
        private string GetShortcutTarget( string lnkFile )
        {
            WshShell shell = new WshShell( );
            IWshShortcut link = ( IWshShortcut ) shell.CreateShortcut( lnkFile );
            return link.TargetPath;
        }
    }
}
