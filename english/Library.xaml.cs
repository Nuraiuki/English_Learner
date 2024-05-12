using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;

namespace english
{
    public partial class Library : ContentPage
    {
        private List<PhrasalVerb> allPhrasalVerbs;

        public Library()
        {
            InitializeComponent();
            allPhrasalVerbs = DatabaseManager.GetPhrasalVerbsWithTranslations();
            phrasalVerbListView.ItemsSource = allPhrasalVerbs;
        }

        // Обработчик события для кнопки поиска
        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            string searchText = searchBar.Text.ToLower(); // Преобразуем введенный текст в нижний регистр для удобства поиска

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                // Фильтруем список фразовых глаголов по введенному тексту
                var filteredPhrasalVerbs = allPhrasalVerbs
                    .Where(verb => verb.Verb.ToLower().Contains(searchText) || verb.Translate.ToLower().Contains(searchText))
                    .ToList();

                phrasalVerbListView.ItemsSource = filteredPhrasalVerbs;
            }
            else
            {
                // Если строка поиска пуста, отображаем все фразовые глаголы
                phrasalVerbListView.ItemsSource = allPhrasalVerbs;
            }
        }

        // Обработчик события для кнопки сортировки по алфавиту
        private bool isSortedAlphabetically = false; // Переменная для отслеживания текущего состояния сортировки

        private void OnSortAlphabeticallyButtonPressed(object sender, EventArgs e)
        {
            if (!isSortedAlphabetically)
            {
                var sortedPhrasalVerbs = allPhrasalVerbs.OrderBy(verb => verb.Verb).ToList();
                phrasalVerbListView.ItemsSource = sortedPhrasalVerbs;
            }
            else
            {
                var sortedPhrasalVerbs = allPhrasalVerbs.OrderByDescending(verb => verb.Verb).ToList();
                phrasalVerbListView.ItemsSource = sortedPhrasalVerbs;
            }

            isSortedAlphabetically = !isSortedAlphabetically; // Инвертируем значение переменной
        }
    }
}
