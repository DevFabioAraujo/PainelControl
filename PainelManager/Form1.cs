using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using IWshRuntimeLibrary;

namespace PainelManager
{
    public partial class Form1 : Form
    {
        // Diretórios de cada aba
        private readonly string dirTERM = @"C:\Programas\TERM\";
        private readonly string dirNETBOOT = @"C:\Programas\NETBOOT";
        private readonly string dirCONFIG = @"C:\Programas\CONFIG";
        private readonly string dirESQUEMAELETRICOS = @"C:\Programas\ESQELETRICO";

        // Caminho do arquivo de configuração
        private readonly string configPath = Path.Combine(
            Environment.GetFolderPath( Environment.SpecialFolder.UserProfile ),
            ".netboot",
            "netboot.ini"
        );

        public Form1()
        {
            InitializeComponent( );
            CarregarProgramas( );
            AdicionarBotaoAtualizarConfig( );
        }

        #region Carregar programas e botões

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
                .Where( f => f.EndsWith( ".exe" ) || f.EndsWith( ".lnk" ) || f.EndsWith( ".pdf" ) || f.EndsWith( ".bat" ) )
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

                ToolTip tt = new ToolTip( );
                tt.SetToolTip( btn, arquivo );

                try
                {
                    string caminhoReal = arquivo;
                    if (Path.GetExtension( arquivo ).ToLower( ) == ".lnk")
                        caminhoReal = GetShortcutTarget( arquivo );

                    if (System.IO.File.Exists( caminhoReal ))
                    {
                        Icon icone = Icon.ExtractAssociatedIcon( caminhoReal );
                        if (icone != null)
                            btn.Image = new Bitmap( icone.ToBitmap( ), new Size( 48, 48 ) );
                    }
                }
                catch { }

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
                        caminhoReal = GetShortcutTarget( caminho );

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

        private string GetShortcutTarget( string lnkFile )
        {
            WshShell shell = new WshShell( );
            IWshShortcut link = ( IWshShortcut ) shell.CreateShortcut( lnkFile );
            return link.TargetPath;
        }

        #endregion

        #region Botão Atualizar home_path

        private void AdicionarBotaoAtualizarConfig()
        {
            var btnAtualizar = new Button
            {
                Text = "Atualizar home_path",
                Width = 200,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter
            };

            btnAtualizar.Click += BtnAtualizarUsuario_Click;

            // Adiciona ao FlowLayoutPanel da aba CONFIG
            flowCONFIG.Controls.Add( btnAtualizar );
        }

        private void BtnAtualizarUsuario_Click( object? sender, EventArgs e )
        {
            try
            {
                if (!System.IO.File.Exists( configPath ))
                {
                    MessageBox.Show( $"Arquivo não encontrado: {configPath}" );
                    return;
                }

                var linhas = System.IO.File.ReadAllLines( configPath ).ToList( );
                string usuarioLogado = Environment.UserName;
                string novoHomePath = $"home_path = C:/Users/{usuarioLogado}/.netboot/ftp";

                for (int i = 0 ; i < linhas.Count ; i++)
                {
                    if (linhas [ i ].TrimStart( ).StartsWith( "home_path" ))
                    {
                        linhas [ i ] = novoHomePath;
                        break;
                    }
                }

                System.IO.File.WriteAllLines( configPath, linhas );
                MessageBox.Show( $"Arquivo atualizado com sucesso!\nNovo caminho: {novoHomePath}" );
            }
            catch (Exception ex)
            {
                MessageBox.Show( $"Erro ao atualizar arquivo: {ex.Message}" );
            }
        }

        #endregion
    }
}









