using Microsoft.VisualStudio.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension
{
    class Formatter
    {
        private readonly Microsoft.VisualStudio.Text.Editor.IWpfTextView view;
        private bool isChangingText;

        public Formatter(Microsoft.VisualStudio.Text.Editor.IWpfTextView view)
        {
            this.view = view;
            this.view.TextBuffer.Changed += TextBuffer_Changed;
            this.view.TextBuffer.PostChanged += TextBuffer_PostChanged;
        }

        private void TextBuffer_Changed(object sender, TextContentChangedEventArgs e)
        {
            if (!isChangingText)
            {
                isChangingText = true;
                FormatCode(e);
            }
        }

        private void TextBuffer_PostChanged(object sender, EventArgs e)
        {
            isChangingText = false;
        }

        private void FormatCode(TextContentChangedEventArgs e)
        {
            if (e.Changes != null)
            {
                for (int i = 0; i < e.Changes.Count; i++)
                {
                    HandleChange(e.Changes[0].NewText);
                }
            }
        }

        private void HandleChange(string newText)
        {
            ITextEdit edit = view.TextBuffer.CreateEdit();
            //edit.Insert(0, "Hello");
            //edit.Apply();
        }
    }
}
