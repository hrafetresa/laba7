using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace laba7
{
    public class HistoryAnswer
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class HistoryEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public List<HistoryAnswer> Answers { get; set; } = new List<HistoryAnswer>();
        public string QuestionText { get; set; } 
    }

    public class HistoryTheme
    {
        public string Name { get; set; }
        public List<HistoryEvent> Events { get; set; } = new List<HistoryEvent>();
    }

    public static class HistoryManager
    {
        private static string _defaultXmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "history_data.xml");

        public static string CustomFilePath { get; set; }

        private static string XmlPath => CustomFilePath ?? _defaultXmlPath;

        private static void CreateEmptyXml()
        {
            try
            {
                XDocument doc = new XDocument(new XElement("Themes"));
                doc.Save(XmlPath);
            }
            catch { }
        }

        public static List<HistoryTheme> LoadData()
        {
            var themes = new List<HistoryTheme>();
            if (!File.Exists(XmlPath))
            {
                CreateEmptyXml();
                return themes;
            }

            try
            {
                XDocument doc = XDocument.Load(XmlPath);
                if (doc.Root == null) return themes;

                foreach (var themeEl in doc.Root.Elements("Theme"))
                {
                    var theme = new HistoryTheme { Name = themeEl.Attribute("Name")?.Value };
                    foreach (var eventEl in themeEl.Elements("Event"))
                    {
                        var ev = new HistoryEvent
                        {
                            Title = eventEl.Attribute("Title")?.Value ?? "",
                            ImageName = eventEl.Attribute("ImageName")?.Value,
                            Description = eventEl.Element("Description")?.Value,
                            QuestionText = eventEl.Element("Question")?.Attribute("Text")?.Value
                        };

                        foreach (var ansEl in eventEl.Element("Question")?.Elements("Answer") ?? Enumerable.Empty<XElement>())
                        {
                            ev.Answers.Add(new HistoryAnswer
                            {
                                Text = ansEl.Value,
                                IsCorrect = (bool?)ansEl.Attribute("IsCorrect") ?? false
                            });
                        }
                        theme.Events.Add(ev);
                    }
                    themes.Add(theme);
                }
            }
            catch { }
            return themes;
        }

        public static void SaveData(List<HistoryTheme> themes)
        {
            try
            {
                XElement root = new XElement("Themes");

                foreach (var theme in themes)
                {
                    XElement themeEl = new XElement("Theme", new XAttribute("Name", theme.Name ?? ""));

                    foreach (var ev in theme.Events)
                    {
                        XElement eventEl = new XElement("Event",
                            new XAttribute("Title", ev.Title ?? ""),
                            ev.ImageName != null ? new XAttribute("ImageName", ev.ImageName) : null,
                            new XElement("Description", ev.Description ?? "")
                        );

                        if (!string.IsNullOrEmpty(ev.QuestionText))
                        {
                            XElement questionEl = new XElement("Question", new XAttribute("Text", ev.QuestionText));

                            foreach (var ans in ev.Answers)
                            {
                                XElement ansEl = new XElement("Answer",
                                    new XAttribute("IsCorrect", ans.IsCorrect ? "True" : "False"),
                                    ans.Text ?? ""
                                );
                                questionEl.Add(ansEl);
                            }

                            eventEl.Add(questionEl);
                        }

                        themeEl.Add(eventEl);
                    }

                    root.Add(themeEl);
                }

                XDocument doc = new XDocument(root);
                doc.Save(XmlPath);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Ошибка при сохранении XML: {ex.Message}");
            }
        }
    }
}