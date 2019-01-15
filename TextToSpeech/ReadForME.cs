using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;

namespace TextToSpeech
{
    public partial class ReadForME : Form
    {
        public ReadForME()
        {
            InitializeComponent();
            
        }
        SpeechSynthesizer speechSynthesizerObj;

        private void Form1_Load(object sender, EventArgs e)
        {
             speechSynthesizerObj=new SpeechSynthesizer();
            btnPause.Enabled = false;
            btnResume.Enabled = false;
            btnStop.Enabled = false;
            
           

        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            speechSynthesizerObj.Dispose();  //Disposes the SpeechSynthesizer object
            if (richTextBox1.Text != "")
            {
              speechSynthesizerObj = new SpeechSynthesizer();
                speechSynthesizerObj.SelectVoiceByHints(VoiceGender.Female);

                speechSynthesizerObj.SpeakAsync(richTextBox1.Text);
                btnPause.Enabled = true;
                btnStop.Enabled = true;
               

            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if(speechSynthesizerObj!=null)
                {
                if(speechSynthesizerObj.State==SynthesizerState.Speaking)  //Gets the current speaking state of the SpeechSynthesizer object.  
                {
                    speechSynthesizerObj.Pause();
                    btnResume.Enabled = true;
                    btnStart.Enabled = false;

                }

            }
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            if(speechSynthesizerObj!=null)
            {
                if (speechSynthesizerObj.State == SynthesizerState.Paused)
                {
                    speechSynthesizerObj.Resume();
                    btnResume.Enabled = false;
                    btnStart.Enabled = true;

                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(speechSynthesizerObj!=null)
            {
                speechSynthesizerObj.Dispose();
                btnStart.Enabled = true;
                btnResume.Enabled = false;
                btnPause.Enabled = false;
                btnStop.Enabled = false;
            }
        }

       
    }
}
