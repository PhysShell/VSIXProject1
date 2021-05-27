using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace Extension
{
    [ContentType("code")]
    [Export(typeof(IWpfTextViewCreationListener))]
    [TextViewRole(PredefinedTextViewRoles.Editable)]
    internal sealed class TextViewCreationListener : Microsoft.VisualStudio.Text.Editor.IWpfTextViewCreationListener
    {
        public void TextViewCreated(IWpfTextView textView)
        {
            new Formatter(textView);
        }
    }
}
