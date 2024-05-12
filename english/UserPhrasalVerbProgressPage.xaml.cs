using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace english
{
    public partial class UserPhrasalVerbProgressPage : ContentPage
    {
        private List<PhrasalVerb> _incompletePhrasalVerbs;

        public UserPhrasalVerbProgressPage(List<PhrasalVerb> incompletePhrasalVerbs)
        {
            InitializeComponent();

            _incompletePhrasalVerbs = incompletePhrasalVerbs;

            phrasalVerbListView.ItemsSource = _incompletePhrasalVerbs;
        }
        private int GetCurrentUserId()
        {
            
            return 1; 
        }
    }
}