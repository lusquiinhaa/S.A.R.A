using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Speech.Recognition; // adicionar namespace


namespace SARA
{
    public partial class Form1 : Form
    {
        //Forms

       // private SelecVoz selectVoice = null;
       
        private SpeechRecognitionEngine engine; // engine de reconhecimento

        private Browser browser;


        private bool isSaraListenig = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadSpeech()
        {
                try
            {
                engine = new SpeechRecognitionEngine(); // instacia
                engine.SetInputToDefaultAudioDevice(); // microfone

                Choices cNumbers = new Choices();

                for (int i = 0; i <= 100; i++)
                    cNumbers.Add(i.ToString());



                Choices c_commandsOfSystem = new Choices();
                c_commandsOfSystem.Add(GrammarRules.WhatTimeIs.ToArray()); //horas
                c_commandsOfSystem.Add(GrammarRules.WhatsDateIs.ToArray()); //Data
                c_commandsOfSystem.Add(GrammarRules.SaraStartListening.ToArray()); // Sara start listening
                c_commandsOfSystem.Add(GrammarRules.SaraStopListening.ToArray()); // Sara Stop listening
             // c_commandsOfSystem.Add(GrammarRules.ChangeVoice.ToArray()); // mudar voz
                c_commandsOfSystem.Add(GrammarRules.OpenProgram.ToArray());




                //"pare de ouvir" -> "Sara"
                GrammarBuilder gb_commandsOfSysten = new GrammarBuilder();
                gb_commandsOfSysten.Append(c_commandsOfSystem);

                Grammar g_commandsOfSystem = new Grammar(gb_commandsOfSysten);
                g_commandsOfSystem.Name = "sys";

                GrammarBuilder gbNumber = new GrammarBuilder();
                gbNumber.Append(cNumbers); // 5 vezes
                gbNumber.Append(new Choices("vezes", "mais", "menos", "por"));
                gbNumber.Append(cNumbers);

                Grammar gNumberes = new Grammar(gbNumber);
                gNumberes.Name = "calc";


                engine.LoadGrammar(g_commandsOfSystem); /// carregar gramatica
                engine.LoadGrammar(gNumberes);

                // Carregar Gramática
                //engine.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(words))));

                engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rec);
                engine.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(audioLevel);
                engine.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(rej);

                engine.RecognizeAsync(RecognizeMode.Multiple); // iniciar o reconhecimento

                Speaker.Speak("estou carregando os arquivos.");
            }
                catch(Exception ex)
            {
                MessageBox.Show("Ocorreu erro no LoadSpeech():" + ex.Message);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSpeech();
            Speaker.Speak("ja carreguei os arquivos, já estou pronta! -- Boa Noite");
        }

        // Metodo de Reconhecimento
        private void rec (object s, SpeechRecognizedEventArgs e)

        {
            string speech = e.Result.Text; // string reconhecida
            float conf = e.Result.Confidence;

            if(conf > 0.35f)
            {
                this.label1.ForeColor = Color.DarkCyan;
                this.label1.ForeColor = Color.LawnGreen;

               // this.label1.Text = "Reconhecido:" + speech;

                if (GrammarRules.SaraStopListening.Any(x => x == speech))
                {
                    isSaraListenig = false;
                }
                else if(GrammarRules.SaraStartListening.Any(x => x == speech))
                {
                    isSaraListenig = true;
                    Speaker.Speak("Olá senhor Lima", "Diga Senhor?", "Como posso ajudar você");
                }
               
                if(isSaraListenig == true )
                {
                    switch (e.Result.Grammar.Name)
                    {
                        case "sys":
                            // se o speeck == "Que horas são"
                            if (GrammarRules.WhatTimeIs.Any(x => x == speech))
                            {
                                Runner.WhatTimeIs();
                            }
                            // Que dia é
                            else if (GrammarRules.WhatsDateIs.Any(x => x == speech))
                            {
                                Runner.WhatDateIs();
                            }
                            //voz
                           /* else if(GrammarRules.ChangeVoice.Any(x => x == speech))
                                 {
                                if(selectVoice == null || selectVoice.IsDisposed == true)
                                selectVoice = new SelecVoz();
                                selectVoice.Show();

                                 } */
                                 else if(GrammarRules.OpenProgram.Any(x => x == speech))
                                    {
                                        switch(speech)
                                {
                                    case "Navegador":
                                        browser = new Browser();
                                        browser.Show();
                                        break;
                                }
                                    }
                            break;
                        case "calc":
                            Speaker.Speak(CalcSolver.Solve(speech));
                            break;
                    }
                }


                
            }
            
        }

        private void Speak(string v)
        {
            throw new NotImplementedException();
        }

        private void audioLevel(object s, AudioLevelUpdatedEventArgs e)

        {
            this.progressBar1.Maximum = 100;
            this.progressBar1.Value = e.AudioLevel;
        }

        private void rej(object s, SpeechRecognitionRejectedEventArgs e)
        {
            this.label1.ForeColor = Color.Red;
        }
    }
}
