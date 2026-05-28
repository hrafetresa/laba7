using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Linq;

namespace laba7
{
    public class HistoryEvent
    {
        public string ImageName { get; set; }
        public string Description { get; set; }
        public string QuestionText { get; set; }
        public List<HistoryAnswer> Answers { get; set; } = new List<HistoryAnswer>();
    }

    public class HistoryAnswer
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class HistoryTheme
    {
        public string Name { get; set; }
        public List<HistoryEvent> Events { get; set; } = new List<HistoryEvent>();
    }

    public static class HistoryManager
    {
        private static readonly string XmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "history_data.xml");

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
                foreach (var themeEl in doc.Root.Elements("Theme"))
                {
                    var theme = new HistoryTheme { Name = themeEl.Attribute("Name")?.Value };
                    foreach (var eventEl in themeEl.Elements("Event"))
                    {
                        var ev = new HistoryEvent
                        {
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
            XElement root = new XElement("HistoryData");
            foreach (var theme in themes)
            {
                XElement themeEl = new XElement("Theme", new XAttribute("Name", theme.Name));
                foreach (var ev in theme.Events)
                {
                    XElement qEl = new XElement("Question", new XAttribute("Text", ev.QuestionText ?? ""));
                    foreach (var ans in ev.Answers)
                    {
                        qEl.Add(new XElement("Answer", new XAttribute("IsCorrect", ans.IsCorrect), ans.Text));
                    }

                    themeEl.Add(new XElement("Event",
                        new XAttribute("ImageName", ev.ImageName ?? ""),
                        new XElement("Description", ev.Description ?? ""),
                        qEl
                    ));
                }
                root.Add(themeEl);
            }
            root.Save(XmlPath);
        }

        private static void CreateEmptyXml()
        {
            new XDocument(new XElement("HistoryData")).Save(XmlPath);
        }
    }
}