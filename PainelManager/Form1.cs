using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace PainelManager
{
    public partial class Form1 : Form
    {
        //Caminho dos executaveis
       // private readonly string diretorio = @"C:\ProgramasExternos";
        private readonly string dirTERM = @"C:\Programas\TERM\";
        private readonly string dirNETBOOT = @"C:\Programas\NETBOOT";
        private readonly string dirCONFIG = @"C:\Programas\CONFIG";
        private readonly string dirESQUEMAELETRICOS = @"C:\Programas\ESQELETRICO";

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
            CarregarExecutaveis( dirESQUEMAELETRICOS, flowESQELETRICO );
        }

                private void CarregarExecutaveis( string diretorio, FlowLayoutPanel painel )
                {
                    if (!Directory.Exists( diretorio )) return;

                        //.exe e .lnk
                        string [ ]arquivos = Directory.GetFiles( diretorio,"*.*").Where(f=>f.EndsWith(".exe")||f.EndsWith(".lnk")||f.EndsWith(".pdf")).ToArray();

                        foreach (var arquivo in arquivos) 
                        {
                            var btn = new Button
                            {
                                Text = Path.GetFileNameWithoutExtension( arquivo ),
                                Width = 120,
                                Height = 120,
                                Tag = arquivo,
                                TextAlign = ContentAlignment.BottomCenter,//TextoAbaixo
                                ImageAlign = ContentAlignment.TopCenter,//Icone em cima
                            };

                            //Tooltip com caminho completo
                            ToolTip tt = new ToolTip( );
                            tt.SetToolTip(btn, arquivo );

                            //tentar extrair o icone do arquivo
                            try
                            {
                                string caminhoReal = arquivo;
                                //Se for atalho .lnk, resolve o caminho real
                                if (Path.GetExtension( arquivo ).ToLower( ) == ".lnk")
                                {
                                  WshShell shell = new WshShell( );
                                  IWshShortcut link = ( IWshShortcut ) shell.CreateShortcut( arquivo );
                                  caminhoReal = link.TargetPath;
                                }


                                if (System.IO.File.Exists( caminhoReal ))
                                {
                                    Icon icone = Icon.ExtractAssociatedIcon( caminhoReal );

                                    if (icone == null)
                                    {
                                        btn.Image =new Bitmap(icone.ToBitmap( ), new Size(48,48));
                                    }
                                }
                }
                            catch (Exception ex)
                            {
                                MessageBox.Show( $"Erro ao executar:{ex.Message}" );
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
                        WshShell shell = new WshShell( );
                        IWshShortcut link = ( IWshShortcut ) shell.CreateShortcut( caminho );
                        caminhoReal = link.TargetPath;
                    }


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
