/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace SARA
{
  public partial class SelecVoz : Form
  {
      private SpeechSynthesizer sp = new SpeechSynthesizer();
    public SelecVoz()
      {
         InitializeComponent();
          comboBox1.Items.Clear();
        foreach(InstalledVoice voice in sp.GetInstalledVoices())
         {
             comboBox1.Items.Add(voice.VoiceInfo.Name);
          }
         comboBox1.SelectedIndex = 0;
      }
   //form carregado
        private void SelecVoz_Load(object sender, EventArgs e)
    {

    }
    
     private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
        //alterar voz
    private void button2_Click(object sender, EventArgs e)
    {
        this.Close;
     }
    //alterar voz
    private void button1_Click(object sender, EventArgs e)
{
       Speaker.SetVoice(comboBox1.SelectedItem.ToString());
          Speaker.Speak("a voz foi alterada", "feito", "como quiser");
    }
  }
}
*/