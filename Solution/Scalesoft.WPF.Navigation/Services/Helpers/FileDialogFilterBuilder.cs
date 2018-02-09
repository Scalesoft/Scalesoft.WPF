using System;
using System.Collections.Generic;
using System.Text;

namespace Scalesoft.WPF.Navigation.Services.Helpers
{
    public class FileDialogFilterBuilder
    {
        private readonly List<FilterItem> m_filterItems;

        public FileDialogFilterBuilder()
        {
            m_filterItems = new List<FilterItem>();
        }

        /// <summary>
        /// Add new item to filter in file dialog
        /// </summary>
        /// <param name="label">Label displayed to user</param>
        /// <param name="fileExtension">List of extensions separated by semicolon. Each extension is in following format: '*.extension'. Example: '*.jpg;*.jpeg;*.png'</param>
        /// <returns></returns>
        public FileDialogFilterBuilder AddFilter(string label, string fileExtension)
        {
            if (label.Contains("|"))
                throw new ArgumentException($"{nameof(label)} contains forbidden char: '|'");

            if (fileExtension.Contains("|"))
                throw new ArgumentException($"{nameof(fileExtension)} contains forbidden char: '|'");
            
            var newFilterItem = new FilterItem
            {
                Label = label,
                FileExtension = fileExtension,
            };
            m_filterItems.Add(newFilterItem);

            return this;
        }

        /// <summary>
        /// Generates filter string for direct use in file dialog
        /// </summary>
        /// <returns></returns>
        public string ToFilterString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var filterItem in m_filterItems)
            {
                stringBuilder.Append(filterItem.Label)
                    .Append('|')
                    .Append(filterItem.FileExtension)
                    .Append('|');
            }

            if (stringBuilder.Length > 0)
            {
                stringBuilder.Length--;
            }

            return stringBuilder.ToString();
        }

        private class FilterItem
        {
            public string Label { get; set; }
            public string FileExtension { get; set; }
        }
    }
}