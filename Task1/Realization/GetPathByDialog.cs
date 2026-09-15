using PaterniLab1.Task1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace PaterniLab1.Task1.Realization
{
    internal class GetPathByDialog:IGetPath
    {
        public string GetPath(string? initialDirectory = null)
        {
            using OpenFileDialog dialog = new()
            {
                Filter = "Supported Files (*.csv;*.json;*.xml)|*.csv;*.json;*.xml|CSV files (*.csv)|*.csv|JSON files (*.json)|*.json|XML files (*.xml)|*.xml|All files (*.*)|*.*",
                FilterIndex = 1,
                InitialDirectory = initialDirectory ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                RestoreDirectory = true,
                Title = "Select a Data File"
            };

            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : string.Empty;
        }
    }
}
