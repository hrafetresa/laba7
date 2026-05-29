using laba7;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using laba7;
using System;
using System.Collections.Generic;
using System.IO;

namespace laba7Tests
{
    [TestClass]
    public class HistoryManagerTests
    {
        private string _testFilePath;

        [TestInitialize]
        public void Setup()
        {
            string fileName = $"test_history_{Guid.NewGuid()}.xml";
            _testFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            HistoryManager.CustomFilePath = _testFilePath;
        }

        [TestCleanup]
        public void TearDown()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }

        [TestMethod]
        public void LoadData_IfFileDoesNotExist_ShouldReturnEmptyList()
        {
            if (File.Exists(_testFilePath)) File.Delete(_testFilePath);

            List<HistoryTheme> result = HistoryManager.LoadData();


            Assert.IsNotNull(result, "Метод LoadData вернул null вместо пустого списка.");
            Assert.AreEqual(0, result.Count, "Список тем должен быть пуст, если файл отсутствует.");
        }

        [TestMethod]
        public void SaveData_And_LoadData_ShouldCorrectlyWriteAndReadThemes()
        {
            var mockThemes = new List<HistoryTheme>
            {
                new HistoryTheme
                {
                    Name = "Тестовая Великая Русь",
                    Events = new List<HistoryEvent>
                    {
                        new HistoryEvent
                        {
                            Title = "Тестовое Событие",
                            Description = "Описание тестового события",
                            ImageName = "test_pic.jpg",
                            Answers = new List<HistoryAnswer>
                            {
                                new HistoryAnswer { Text = "Ответ 1", IsCorrect = true },
                                new HistoryAnswer { Text = "Ответ 2", IsCorrect = false }
                            }
                        }
                    }
                }
            };

            HistoryManager.SaveData(mockThemes);

            List<HistoryTheme> loadedThemes = HistoryManager.LoadData();

            Assert.AreEqual(1, loadedThemes.Count, "Количество тем не совпадает.");
            Assert.AreEqual("Тестовая Великая Русь", loadedThemes[0].Name, "Название темы исказилось при чтении/записи.");

            Assert.AreEqual(1, loadedThemes[0].Events.Count, "Количество событий в теме не совпадает.");
            Assert.AreEqual("Тестовое Событие", loadedThemes[0].Events[0].Title, "Название события не совпадает.");
            Assert.AreEqual("test_pic.jpg", loadedThemes[0].Events[0].ImageName, "Имя картинки потерялось.");

        }

        [TestMethod]
        public void SaveData_InAdminMode_ShouldAllowModifyingExistingData()
        {
            var initialThemes = new List<HistoryTheme>
            {
                new HistoryTheme { Name = "Эпоха Петра", Events = new List<HistoryEvent>() }
            };
            HistoryManager.SaveData(initialThemes);

            List<HistoryTheme> themesToEdit = HistoryManager.LoadData();

            themesToEdit[0].Name = "Эпоха Петра I (Изменено)"; 
            themesToEdit[0].Events.Add(new HistoryEvent
            {
                Title = "Новое Админское Событие",
                Answers = new List<HistoryAnswer>()
            });

            HistoryManager.SaveData(themesToEdit);

            List<HistoryTheme> finalThemes = HistoryManager.LoadData();

            Assert.AreEqual(1, finalThemes.Count);
            Assert.AreEqual("Эпоха Петра I (Изменено)", finalThemes[0].Name, "Изменение названия темы не сохранилось.");
            Assert.AreEqual(1, finalThemes[0].Events.Count, "Новое событие, добавленное админом, не зафиксировано в XML.");
            Assert.AreEqual("Новое Админское Событие", finalThemes[0].Events[0].Title);
        }
    }
}