using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.Design;
using System.Collections;

namespace ispda.Controls
{
    [Designer(typeof(DesignTimeRichTextBoxDesigner))]  // ← вот здесь подключается кастомный дизайнер
    [ToolboxItem(true)]
    public class RichTextBoxWithRTF: RichTextBox
    {

        private string _initialRtf = null;

        // Свойство для отображения в дизайнере
        [Editor(typeof(RtfEditor), typeof(UITypeEditor))]
        [Category("Appearance")]
        [Description("RTF-текст с форматированием")]
        public string RichText
        {
            get => this.Rtf;
            set
            {
                // Сохраняем значение, но не применяем сразу, если handle ещё не создан
                if (this.IsHandleCreated)
                    this.Rtf = value;
                else
                    _initialRtf = value;
            }
        }

        // Переопределяем создание handle – гарантированно применим RTF после создания окна
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!string.IsNullOrEmpty(_initialRtf))
            {
                this.Rtf = _initialRtf;
                _initialRtf = null;
            }
        }

        // Предотвращаем сброс Rtf при изменении Text (некоторые операции выставляют Text)
        public override string Text
        {
            get => base.Text;
            set
            {
                // Если присваивают пустую строку и у нас был RTF – не даём его затереть
                if (string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(this.Rtf))
                    return;
                base.Text = value;
            }
        }


    }
    public class RtfEditor : UITypeEditor
    {


        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            // Показываем кнопку с многоточием (...)
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            string tempFile = Path.GetTempFileName() + ".rtf";
            File.WriteAllText(tempFile, value?.ToString() ?? "");

            Process editor = new Process();
            editor.StartInfo.FileName = "notepad.exe";
            editor.StartInfo.Arguments = "\"" + tempFile + "\"";
            editor.Start();
            editor.WaitForExit();

            string newRtf = File.ReadAllText(tempFile);
            File.Delete(tempFile);
            return newRtf;
        }
    }
    public class DesignTimeRichTextBoxDesigner : ControlDesigner
    {
        
    }
}
